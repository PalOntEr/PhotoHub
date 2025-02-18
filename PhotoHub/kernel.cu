// kernel.cu
//Compiler: nvcc
//Bash Line: nvcc -o kernel.dll --shared kernel.cu
//BGR image format
//pixel_index + 2 red
//pixel_index + 1 green
//pixel_index blue

#include <math_constants.h>
#include <curand_kernel.h>

extern "C" __global__ void generate_histogram_kernel(int width, int height, unsigned char* pixels, int* red_histogram, int* green_histogram, int* blue_histogram) {
    int idx = threadIdx.x + blockIdx.x * blockDim.x;
    if (idx < width * height) {
        int pixel_index = idx * 3;
        atomicAdd(&red_histogram[pixels[pixel_index + 2]], 1);
        atomicAdd(&green_histogram[pixels[pixel_index + 1]], 1);
        atomicAdd(&blue_histogram[pixels[pixel_index]], 1);
    }
}

extern "C" __global__ void grayscale_filter_kernel(int width, int height, unsigned char* pixels, unsigned char* result) {
    int idx = threadIdx.x + blockIdx.x * blockDim.x;

    if (idx < width * height) {
        int pixel_index = idx * 3;
        unsigned char grayscale_value = (pixels[pixel_index] + pixels[pixel_index + 1] + pixels[pixel_index + 2]) / 3;
        result[pixel_index] = grayscale_value;
        result[pixel_index + 1] = grayscale_value;
        result[pixel_index + 2] = grayscale_value;
    }
}
extern "C" __global__ void negative_filter_kernel(int width, int height, unsigned char* pixels, unsigned char* result) {
    int idx = threadIdx.x + blockIdx.x * blockDim.x;

    if (idx < width * height) {
        int pixel_index = idx * 3;
        result[pixel_index] = 255 - pixels[pixel_index];
        result[pixel_index + 1] = 255 - pixels[pixel_index + 1];
        result[pixel_index + 2] = 255 - pixels[pixel_index + 2];
    }
}
extern "C" __global__ void sepia_filter_kernel(int width, int height, unsigned char* pixels, unsigned char* result) {
    int idx = threadIdx.x + blockIdx.x * blockDim.x;

    if (idx < width * height) {
        int pixel_index = idx * 3;
        unsigned char gray_value = static_cast<unsigned char>(pixels[pixel_index] * 0.3f + pixels[pixel_index + 1] * 0.59f + pixels[pixel_index + 2] * 0.11f);
        result[pixel_index + 2] = min(255, gray_value + 40);
        result[pixel_index + 1] = min(255, gray_value + 20);
        result[pixel_index] = min(255, gray_value);
    }
}
extern "C" __global__ void gaussian_filter_kernel(int width, int height, unsigned char* pixels, unsigned char* result) {
    int idx = threadIdx.x + blockIdx.x * blockDim.x;

    if (idx < width * height) {
        int pixel_index = idx * 3;
        float pr = 0.0f;
        float pg = 0.0f;
        float pb = 0.0f;
        float total_weight = 0.0f;

        int kernel_radius = 1;
        float kernel[3][3] = {
            {1.0f / 16, 1.0f / 8, 1.0f / 16},
            {1.0f / 8, 1.0f / 4, 1.0f / 8},
            {1.0f / 16, 1.0f / 8, 1.0f / 16}
        };

        for (int ky = -kernel_radius; ky <= kernel_radius; ky++) {
            for (int kx = -kernel_radius; kx <= kernel_radius; kx++) {
                int neighbor_x = (idx % width) + kx;
                int neighbor_y = (idx / width) + ky;
                if (neighbor_x >= 0 && neighbor_x < width && neighbor_y >= 0 && neighbor_y < height) {
                    int neighbor_index = (neighbor_y * width + neighbor_x) * 3;
                    float weight = kernel[ky + kernel_radius][kx + kernel_radius];
                    pr += pixels[neighbor_index + 2] * weight;
                    pg += pixels[neighbor_index + 1] * weight;
                    pb += pixels[neighbor_index] * weight;
                    total_weight += weight;
                }
            }
        }

        result[pixel_index + 2] = static_cast<unsigned char>(pr / total_weight);
        result[pixel_index + 1] = static_cast<unsigned char>(pg / total_weight);
        result[pixel_index] = static_cast<unsigned char>(pb / total_weight);
    }
}
extern "C" __global__ void emboss_filter_kernel(int width, int height, unsigned char* pixels, unsigned char* result) {
    int idx = threadIdx.x + blockIdx.x * blockDim.x;

    if (idx < width * height) {
        int pixel_index = idx * 3;
        float pr = 0.0f;
        float pg = 0.0f;
        float pb = 0.0f;

        int kernel_radius = 1;
        float mask1[3][3] = {
            {0, 1, 0},
            {0, 0, 0},
            {0, -1, 0}
        };
        float mask2[3][3] = {
            {1, 0, 0},
            { 0, 0, 0 },
            {0, 0, -1}
        };
        float mask3[3][3] = {
            {0, 0, 0},
            {1, 0, -1},
            {0, 0, 0}
        };
        float mask4[3][3] = {
            {0, 0, 1},
            {0, 0, 0},
            {-1, 0, 0}
        };

        for (int ky = -kernel_radius; ky <= kernel_radius; ky++) {
            for (int kx = -kernel_radius; kx <= kernel_radius; kx++) {
                int neighbor_x = (idx % width) + kx;
                int neighbor_y = (idx / width) + ky;
                if (neighbor_x >= 0 && neighbor_x < width && neighbor_y >= 0 && neighbor_y < height) {
                    int neighbor_index = (neighbor_y * width + neighbor_x) * 3;
                    float weight = mask1[ky + kernel_radius][kx + kernel_radius];
					weight += mask2[ky + kernel_radius][kx + kernel_radius];
					weight += mask3[ky + kernel_radius][kx + kernel_radius];
					weight += mask4[ky + kernel_radius][kx + kernel_radius];
                    pr += pixels[neighbor_index + 2] * weight;
                    pg += pixels[neighbor_index + 1] * weight;
                    pb += pixels[neighbor_index] * weight;
                }
            }
        }

        result[pixel_index + 2] = min(max(static_cast<unsigned char>(pr) + 128, 0), 255);
        result[pixel_index + 1] = min(max(static_cast<unsigned char>(pg) + 128, 0), 255);
        result[pixel_index] = min(max(static_cast<unsigned char>(pb) + 128, 0), 255);
    }

}
extern "C" __global__ void edge_filter_kernel(int width, int height, unsigned char* pixels, unsigned char* result) {
    int idx = threadIdx.x + blockIdx.x * blockDim.x;

    if (idx < width * height) {
        int kernel_radius = 1;
        float sobel_x[3][3] = {
            {1, 2, 1},
            {0, 0, 0},
            {-1, -2, -1}
        };
        float sobel_y[3][3] = {
            {-1, 0, 1},
            {-2, 0, 2},
            {-1, 0, 1}
        };

        int pixel_index = idx * 3;
        int Lx = 0;
        int Ly = 0;

        for (int ky = -kernel_radius; ky <= kernel_radius; ky++) {
            for (int kx = -kernel_radius; kx <= kernel_radius; kx++) {
                int neighbor_x = (idx % width) + kx;
                int neighbor_y = (idx / width) + ky;
                if (neighbor_x >= 0 && neighbor_x < width && neighbor_y >= 0 && neighbor_y < height) {
                    int neighbor_index = (neighbor_y * width + neighbor_x) * 3;

                    unsigned char grayscale_value = (pixels[neighbor_index] + pixels[neighbor_index + 1] + pixels[neighbor_index + 2]) / 3;

                    Lx += sobel_x[ky + kernel_radius][kx + kernel_radius] * grayscale_value;
                    Ly += sobel_y[ky + kernel_radius][kx + kernel_radius] * grayscale_value;
                }
            }
        }

        float gradient_magnitude = sqrtf(Lx * Lx + Ly * Ly);

        gradient_magnitude = gradient_magnitude > 50 ? 255 : 0;

        result[pixel_index + 2] = static_cast<unsigned char>(min(max(gradient_magnitude, 0.0f), 255.0f));
        result[pixel_index + 1] = static_cast<unsigned char>(min(max(gradient_magnitude, 0.0f), 255.0f));
        result[pixel_index] = static_cast<unsigned char>(min(max(gradient_magnitude, 0.0f), 255.0f));
    }
}
extern "C" __global__ void thermal_filter_kernel(int width, int height, unsigned char* pixels, unsigned char* result) {  
    int idx = threadIdx.x + blockIdx.x * blockDim.x;  
  
    if (idx < width * height) {  
        int pixel_index = idx * 3;  
        unsigned char gray_value = (pixels[pixel_index] + pixels[pixel_index + 1] + pixels[pixel_index + 2]) / 3;  
        unsigned char r, g, b;  
  
        if (gray_value < 64) {  
            r = 4 * gray_value;  
            g = 0;  
            b = 0;  
        } else if (gray_value < 128) {  
            r = 255 - 4 * (gray_value - 64);  
            g = 4 * (gray_value - 64);  
            b = 0;  
        } else if (gray_value < 192) {  
            r = 0;  
            g = 255 - 4 * (gray_value - 128);  
            b = 4 * (gray_value - 128);  
        } else {  
            r = 0;  
            g = 4 * (gray_value - 192);  
            b = 255;  
        }  
  
        result[pixel_index + 2] = r;  
        result[pixel_index + 1] = g;  
        result[pixel_index] = b;  
    }  
}
extern "C" __global__ void contrast_filter_kernel(int width, int height, unsigned char* pixels, unsigned char* result) {
    int idx = threadIdx.x + blockIdx.x * blockDim.x;

    if (idx < width * height) {
        int pixel_index = idx * 3;

		float contrast = 2.0f;

		result[pixel_index + 2] = min(max(static_cast<unsigned char>(contrast * (pixels[pixel_index + 2] - 128) + 128), 0), 255);
		result[pixel_index + 1] = min(max(static_cast<unsigned char>(contrast * (pixels[pixel_index + 1] - 128) + 128), 0), 255);
		result[pixel_index] = min(max(static_cast<unsigned char>(contrast * (pixels[pixel_index] - 128) + 128), 0), 255);
    }
}
extern "C" __global__ void sharpen_filter_kernel(int width, int height, unsigned char* pixels, unsigned char* result) {
    int idx = threadIdx.x + blockIdx.x * blockDim.x;

    if (idx < width * height) {
        int pixel_index = idx * 3;
        float pr = 0.0f;
        float pg = 0.0f;
        float pb = 0.0f;
        float total_weight = 0.0f;

        int kernel_radius = 1;
        float kernel[3][3] = {
            {1.0f / 16, 1.0f / 8, 1.0f / 16},
            {1.0f / 8, 1.0f / 4, 1.0f / 8},
            {1.0f / 16, 1.0f / 8, 1.0f / 16}
        };

        for (int ky = -kernel_radius; ky <= kernel_radius; ky++) {
            for (int kx = -kernel_radius; kx <= kernel_radius; kx++) {
                int neighbor_x = (idx % width) + kx;
                int neighbor_y = (idx / width) + ky;
                if (neighbor_x >= 0 && neighbor_x < width && neighbor_y >= 0 && neighbor_y < height) {
                    int neighbor_index = (neighbor_y * width + neighbor_x) * 3;
                    float weight = kernel[ky + kernel_radius][kx + kernel_radius];
                    pr += pixels[neighbor_index + 2] * weight;
                    pg += pixels[neighbor_index + 1] * weight;
                    pb += pixels[neighbor_index] * weight;
                    total_weight += weight;
                }
            }
        }

		int coarse[3] = { 0 };

        coarse[0] = static_cast<unsigned char>(pr / total_weight);
		coarse[1] = static_cast<unsigned char>(pg / total_weight);
		coarse[2] = static_cast<unsigned char>(pb / total_weight);

		result[pixel_index + 2] = static_cast<unsigned char>((pixels[pixel_index + 2] * 1.5) - (coarse[0] * 0.5));
		result[pixel_index + 1] = static_cast<unsigned char>((pixels[pixel_index + 1] * 1.5) - (coarse[1] * 0.5));
		result[pixel_index] = static_cast<unsigned char>((pixels[pixel_index] * 1.5) - (coarse[2] * 0.5));

    }
}
extern "C" __global__ void noise_filter_kernel(int width, int height, unsigned char* pixels, unsigned char* result) {
    int idx = threadIdx.x + blockIdx.x * blockDim.x;

    if (idx < width * height) {
        int pixel_index = idx * 3;
		int noise = 20;
		unsigned int seed = 0;

        curandState state;
        curand_init(seed, idx, 0, &state);

        result[pixel_index + 2] = min(max(static_cast<unsigned char>(pixels[pixel_index + 2] + ((curand(&state) % (2 * noise)) - noise) / 3), 0), 255);
        result[pixel_index + 1] = min(max(static_cast<unsigned char>(pixels[pixel_index + 1] + ((curand(&state) % (2 * noise)) - noise) / 3), 0), 255);
        result[pixel_index] = min(max(static_cast<unsigned char>(pixels[pixel_index] + ((curand(&state) % (2 * noise)) - noise) / 3), 0), 255);
    }
}
extern "C" __global__ void tilt_filter_kernel(int width, int height, unsigned char* pixels, unsigned char* result) {
    int idx = threadIdx.x + blockIdx.x * blockDim.x;

    if (idx < width * height) {
        int pixel_index = idx * 3;
        int x = idx % width;
        int y = idx / width;

        float center_x = width / 2.0f;
        float center_y = height / 2.0f;
		float distance = sqrtf((x - center_x) * (x - center_x) + (y - center_y) * (y - center_y));

		float blur_radius = min(height / 3, width / 3);

        float blur_amount = distance <= blur_radius ? 0 : distance;

        if (blur_amount > 0.0f) {
            float pr = 0.0f, pg = 0.0f, pb = 0.0f;
            float total_weight = 0.0f;
            int kernel_radius = 1;
            float kernel[3][3] = {
                {1.0f / 16, 1.0f / 8, 1.0f / 16},
                {1.0f / 8, 1.0f / 4, 1.0f / 8},
                {1.0f / 16, 1.0f / 8, 1.0f / 16}
            };

            for (int ky = -kernel_radius; ky <= kernel_radius; ky++) {
                for (int kx = -kernel_radius; kx <= kernel_radius; kx++) {
                    int neighbor_x = x + kx;
                    int neighbor_y = y + ky;
                    if (neighbor_x >= 0 && neighbor_x < width && neighbor_y >= 0 && neighbor_y < height) {
                        int neighbor_index = (neighbor_y * width + neighbor_x) * 3;
                        float weight = kernel[ky + kernel_radius][kx + kernel_radius];
                        pr += pixels[neighbor_index + 2] * weight;
                        pg += pixels[neighbor_index + 1] * weight;
                        pb += pixels[neighbor_index] * weight;
                        total_weight += weight;
                    }
                }
            }

            result[pixel_index + 2] = static_cast<unsigned char>(pr / total_weight);
            result[pixel_index + 1] = static_cast<unsigned char>(pg / total_weight);
            result[pixel_index] = static_cast<unsigned char>(pb / total_weight);
        }
        else {
            result[pixel_index + 2] = pixels[pixel_index + 2];
            result[pixel_index + 1] = pixels[pixel_index + 1];
            result[pixel_index] = pixels[pixel_index];
        }
    }
}
extern "C" __global__ void sketch_filter_kernel(int width, int height, unsigned char* pixels, unsigned char* result) {
    int idx = threadIdx.x + blockIdx.x * blockDim.x;

    if (idx < width * height) {
        int kernel_radius = 1;
        float sobel_x[3][3] = {
            {1, 2, 1},
            {0, 0, 0},
            {-1, -2, -1}
        };
        float sobel_y[3][3] = {
            {-1, 0, 1},
            {-2, 0, 2},
            {-1, 0, 1}
        };

        int pixel_index = idx * 3;
        int Lx = 0;
        int Ly = 0;

        for (int ky = -kernel_radius; ky <= kernel_radius; ky++) {
            for (int kx = -kernel_radius; kx <= kernel_radius; kx++) {
                int neighbor_x = (idx % width) + kx;
                int neighbor_y = (idx / width) + ky;
                if (neighbor_x >= 0 && neighbor_x < width && neighbor_y >= 0 && neighbor_y < height) {
                    int neighbor_index = (neighbor_y * width + neighbor_x) * 3;

                    unsigned char grayscale_value = (pixels[neighbor_index] + pixels[neighbor_index + 1] + pixels[neighbor_index + 2]) / 3;

                    Lx += sobel_x[ky + kernel_radius][kx + kernel_radius] * grayscale_value;
                    Ly += sobel_y[ky + kernel_radius][kx + kernel_radius] * grayscale_value;
                }
            }
        }

        float gradient_magnitude = sqrtf(Lx * Lx + Ly * Ly);

        result[pixel_index + 2] = static_cast<unsigned char>(min(max(gradient_magnitude, 0.0f), 255.0f));
        result[pixel_index + 1] = static_cast<unsigned char>(min(max(gradient_magnitude, 0.0f), 255.0f));
        result[pixel_index] = static_cast<unsigned char>(min(max(gradient_magnitude, 0.0f), 255.0f));

        unsigned char gray_value = static_cast<unsigned char>(result[pixel_index] * 0.3f + result[pixel_index + 1] * 0.59f + result[pixel_index + 2] * 0.11f);
        result[pixel_index + 2] = min(255, gray_value + 40);
        result[pixel_index + 1] = min(255, gray_value + 20);
        result[pixel_index] = min(255, gray_value);
    }
}

extern "C" __global__ void color_detection_kernel(int width, int height, unsigned char* pixels, unsigned char* result, unsigned char* color) {
    int idx = threadIdx.x + blockIdx.x * blockDim.x;

    if (idx < width * height) {
		int pixel_index = idx * 3;

		bool color_detected = 
            (pixels[pixel_index + 2] <= color[0] + 20 && pixels[pixel_index + 2] >= color[0] - 20) &&
			(pixels[pixel_index + 1] <= color[1] + 20 && pixels[pixel_index + 1] >= color[1] - 20) &&
			(pixels[pixel_index] <= color[2] + 20 && pixels[pixel_index] >= color[2] - 20);

		result[pixel_index + 2] = color_detected ? color[0] : 128;
		result[pixel_index + 1] = color_detected ? color[1] : 128;
		result[pixel_index] = color_detected ? color[2] : 128;
    }
}





extern "C" __declspec(dllexport) void GenerateHistograms(int width, int height, unsigned char* pixels, int* red_histogram, int* green_histogram, int* blue_histogram) {
    unsigned char* d_pixels;
    int* d_red_histogram;
    int* d_green_histogram;
    int* d_blue_histogram;

    cudaMalloc((void**)&d_pixels, width * height * 3 * sizeof(unsigned char));
    cudaMalloc((void**)&d_red_histogram, 256 * sizeof(int));
    cudaMalloc((void**)&d_green_histogram, 256 * sizeof(int));
    cudaMalloc((void**)&d_blue_histogram, 256 * sizeof(int));

    cudaMemcpy(d_pixels, pixels, width * height * 3 * sizeof(unsigned char), cudaMemcpyHostToDevice);
    cudaMemset(d_red_histogram, 0, 256 * sizeof(int));
    cudaMemset(d_green_histogram, 0, 256 * sizeof(int));
    cudaMemset(d_blue_histogram, 0, 256 * sizeof(int));

    int blockSize = 256;
    int numBlocks = (width * height + blockSize - 1) / blockSize;
    generate_histogram_kernel << <numBlocks, blockSize >> > (width, height, d_pixels, d_red_histogram, d_green_histogram, d_blue_histogram);

    cudaMemcpy(red_histogram, d_red_histogram, 256 * sizeof(int), cudaMemcpyDeviceToHost);
    cudaMemcpy(green_histogram, d_green_histogram, 256 * sizeof(int), cudaMemcpyDeviceToHost);
    cudaMemcpy(blue_histogram, d_blue_histogram, 256 * sizeof(int), cudaMemcpyDeviceToHost);

    cudaFree(d_pixels);
    cudaFree(d_red_histogram);
    cudaFree(d_green_histogram);
    cudaFree(d_blue_histogram);
}

extern "C" __declspec(dllexport) void GrayscaleFilter(int width, int height, unsigned char* pixels, unsigned char* result) {
    unsigned char* d_pixels;
	unsigned char* d_result;

    cudaMalloc((void**)&d_pixels, width * height * 3 * sizeof(unsigned char));
	cudaMalloc((void**)&d_result, width * height * 3 * sizeof(unsigned char));

	cudaMemcpy(d_pixels, pixels, width * height * 3 * sizeof(unsigned char), cudaMemcpyHostToDevice);

	int blockSize = 256;
	int numBlocks = (width * height + blockSize - 1) / blockSize;
	grayscale_filter_kernel << <numBlocks, blockSize >> > (width, height, d_pixels, d_result);

	cudaMemcpy(result, d_result, width * height * 3 * sizeof(unsigned char), cudaMemcpyDeviceToHost);

    cudaFree(d_pixels);
	cudaFree(d_result);
}

extern "C" __declspec(dllexport) void NegativeFilter(int width, int height, unsigned char* pixels, unsigned char* result) {

    unsigned char* d_pixels;
	unsigned char* d_result;

	cudaMalloc((void**)&d_pixels, width * height * 3 * sizeof(unsigned char));
	cudaMalloc((void**)&d_result, width * height * 3 * sizeof(unsigned char));

	cudaMemcpy(d_pixels, pixels, width * height * 3 * sizeof(unsigned char), cudaMemcpyHostToDevice);

	int blockSize = 256;
	int numBlocks = (width * height + blockSize - 1) / blockSize;
	negative_filter_kernel << <numBlocks, blockSize >> > (width, height, d_pixels, d_result);

	cudaMemcpy(result, d_result, width * height * 3 * sizeof(unsigned char), cudaMemcpyDeviceToHost);

	cudaFree(d_pixels);
	cudaFree(d_result);
}

extern "C" __declspec(dllexport) void SepiaFilter(int width, int height, unsigned char* pixels, unsigned char* result) {

    unsigned char* d_pixels;
	unsigned char* d_result;

	cudaMalloc((void**)&d_pixels, width * height * 3 * sizeof(unsigned char));
	cudaMalloc((void**)&d_result, width * height * 3 * sizeof(unsigned char));

	cudaMemcpy(d_pixels, pixels, width * height * 3 * sizeof(unsigned char), cudaMemcpyHostToDevice);

	int blockSize = 256;
	int numBlocks = (width * height + blockSize - 1) / blockSize;
	sepia_filter_kernel << <numBlocks, blockSize >> > (width, height, d_pixels, d_result);

	cudaMemcpy(result, d_result, width * height * 3 * sizeof(unsigned char), cudaMemcpyDeviceToHost);

	cudaFree(d_pixels);
	cudaFree(d_result);
}

extern "C" __declspec(dllexport) void GaussianFilter(int width, int height, unsigned char* pixels, unsigned char* result) {

    unsigned char* d_pixels;
	unsigned char* d_result;

	cudaMalloc((void**)&d_pixels, width * height * 3 * sizeof(unsigned char));
	cudaMalloc((void**)&d_result, width * height * 3 * sizeof(unsigned char));

	cudaMemcpy(d_pixels, pixels, width * height * 3 * sizeof(unsigned char), cudaMemcpyHostToDevice);

	int blockSize = 256;
	int numBlocks = (width * height + blockSize - 1) / blockSize;
	gaussian_filter_kernel << <numBlocks, blockSize >> > (width, height, d_pixels, d_result);

	cudaMemcpy(result, d_result, width * height * 3 * sizeof(unsigned char), cudaMemcpyDeviceToHost);

	cudaFree(d_pixels);
	cudaFree(d_result);
}

extern "C" __declspec(dllexport) void EmbossFilter(int width, int height, unsigned char* pixels, unsigned char* result) {

    unsigned char* d_pixels;
	unsigned char* d_result;

	cudaMalloc((void**)&d_pixels, width * height * 3 * sizeof(unsigned char));
	cudaMalloc((void**)&d_result, width * height * 3 * sizeof(unsigned char));

	cudaMemcpy(d_pixels, pixels, width * height * 3 * sizeof(unsigned char), cudaMemcpyHostToDevice);

	int blockSize = 256;
	int numBlocks = (width * height + blockSize - 1) / blockSize;
	emboss_filter_kernel << <numBlocks, blockSize >> > (width, height, d_pixels, d_result);

	cudaMemcpy(result, d_result, width * height * 3 * sizeof(unsigned char), cudaMemcpyDeviceToHost);

	cudaFree(d_pixels);
	cudaFree(d_result);
}

extern "C" __declspec(dllexport) void EdgeFilter(int width, int height, unsigned char* pixels, unsigned char* result) {

    unsigned char* d_pixels;
	unsigned char* d_result;

	cudaMalloc((void**)&d_pixels, width * height * 3 * sizeof(unsigned char));
	cudaMalloc((void**)&d_result, width * height * 3 * sizeof(unsigned char));

	cudaMemcpy(d_pixels, pixels, width * height * 3 * sizeof(unsigned char), cudaMemcpyHostToDevice);

	int blockSize = 256;
	int numBlocks = (width * height + blockSize - 1) / blockSize;
    edge_filter_kernel << <numBlocks, blockSize >> > (width, height, d_pixels, d_result);

	cudaMemcpy(result, d_result, width * height * 3 * sizeof(unsigned char), cudaMemcpyDeviceToHost);

	cudaFree(d_pixels);
	cudaFree(d_result);
}

extern "C" __declspec(dllexport) void ThermalFilter(int width, int height, unsigned char* pixels, unsigned char* result) {

    unsigned char* d_pixels;
	unsigned char* d_result;

	cudaMalloc((void**)&d_pixels, width * height * 3 * sizeof(unsigned char));
	cudaMalloc((void**)&d_result, width * height * 3 * sizeof(unsigned char));

	cudaMemcpy(d_pixels, pixels, width * height * 3 * sizeof(unsigned char), cudaMemcpyHostToDevice);

	int blockSize = 256;
	int numBlocks = (width * height + blockSize - 1) / blockSize;
    thermal_filter_kernel << <numBlocks, blockSize >> > (width, height, d_pixels, d_result);

	cudaMemcpy(result, d_result, width * height * 3 * sizeof(unsigned char), cudaMemcpyDeviceToHost);

	cudaFree(d_pixels);
	cudaFree(d_result);
}

extern "C" __declspec(dllexport) void ContrastFilter(int width, int height, unsigned char* pixels, unsigned char* result) {

    unsigned char* d_pixels;
	unsigned char* d_result;

	cudaMalloc((void**)&d_pixels, width * height * 3 * sizeof(unsigned char));
	cudaMalloc((void**)&d_result, width * height * 3 * sizeof(unsigned char));

	cudaMemcpy(d_pixels, pixels, width * height * 3 * sizeof(unsigned char), cudaMemcpyHostToDevice);

	int blockSize = 256;
	int numBlocks = (width * height + blockSize - 1) / blockSize;
    contrast_filter_kernel << <numBlocks, blockSize >> > (width, height, d_pixels, d_result);

	cudaMemcpy(result, d_result, width * height * 3 * sizeof(unsigned char), cudaMemcpyDeviceToHost);

	cudaFree(d_pixels);
	cudaFree(d_result);
}

extern "C" __declspec(dllexport) void SharpenFilter(int width, int height, unsigned char* pixels, unsigned char* result) {

    unsigned char* d_pixels;
	unsigned char* d_result;

	cudaMalloc((void**)&d_pixels, width * height * 3 * sizeof(unsigned char));
	cudaMalloc((void**)&d_result, width * height * 3 * sizeof(unsigned char));

	cudaMemcpy(d_pixels, pixels, width * height * 3 * sizeof(unsigned char), cudaMemcpyHostToDevice);

	int blockSize = 256;
	int numBlocks = (width * height + blockSize - 1) / blockSize;
    sharpen_filter_kernel << <numBlocks, blockSize >> > (width, height, d_pixels, d_result);

	cudaMemcpy(result, d_result, width * height * 3 * sizeof(unsigned char), cudaMemcpyDeviceToHost);

	cudaFree(d_pixels);
	cudaFree(d_result);
}

extern "C" __declspec(dllexport) void NoiseFilter(int width, int height, unsigned char* pixels, unsigned char* result) {

    unsigned char* d_pixels;
	unsigned char* d_result;

	cudaMalloc((void**)&d_pixels, width * height * 3 * sizeof(unsigned char));
	cudaMalloc((void**)&d_result, width * height * 3 * sizeof(unsigned char));

	cudaMemcpy(d_pixels, pixels, width * height * 3 * sizeof(unsigned char), cudaMemcpyHostToDevice);

	int blockSize = 256;
	int numBlocks = (width * height + blockSize - 1) / blockSize;
    noise_filter_kernel << <numBlocks, blockSize >> > (width, height, d_pixels, d_result);

	cudaMemcpy(result, d_result, width * height * 3 * sizeof(unsigned char), cudaMemcpyDeviceToHost);

	cudaFree(d_pixels);
	cudaFree(d_result);
}

extern "C" __declspec(dllexport) void TiltFilter(int width, int height, unsigned char* pixels, unsigned char* result) {

    unsigned char* d_pixels;
	unsigned char* d_result;

	cudaMalloc((void**)&d_pixels, width * height * 3 * sizeof(unsigned char));
	cudaMalloc((void**)&d_result, width * height * 3 * sizeof(unsigned char));

	cudaMemcpy(d_pixels, pixels, width * height * 3 * sizeof(unsigned char), cudaMemcpyHostToDevice);

	int blockSize = 256;
	int numBlocks = (width * height + blockSize - 1) / blockSize;
    tilt_filter_kernel << <numBlocks, blockSize >> > (width, height, d_pixels, d_result);

	cudaMemcpy(result, d_result, width * height * 3 * sizeof(unsigned char), cudaMemcpyDeviceToHost);

	cudaFree(d_pixels);
	cudaFree(d_result);
}

extern "C" __declspec(dllexport) void SketchFilter(int width, int height, unsigned char* pixels, unsigned char* result) {

    unsigned char* d_pixels;
	unsigned char* d_result;

	cudaMalloc((void**)&d_pixels, width * height * 3 * sizeof(unsigned char));
	cudaMalloc((void**)&d_result, width * height * 3 * sizeof(unsigned char));

	cudaMemcpy(d_pixels, pixels, width * height * 3 * sizeof(unsigned char), cudaMemcpyHostToDevice);

	int blockSize = 256;
	int numBlocks = (width * height + blockSize - 1) / blockSize;
    sketch_filter_kernel << <numBlocks, blockSize >> > (width, height, d_pixels, d_result);

	cudaMemcpy(result, d_result, width * height * 3 * sizeof(unsigned char), cudaMemcpyDeviceToHost);

	cudaFree(d_pixels);
	cudaFree(d_result);
}

extern "C" __declspec(dllexport) void ColorDetection(int width, int height, unsigned char* pixels, unsigned char* result, unsigned char* color) {

    unsigned char* d_pixels;
    unsigned char* d_color;
	unsigned char* d_result;

	cudaMalloc((void**)&d_pixels, width * height * 3 * sizeof(unsigned char));
	cudaMalloc((void**)&d_result, width * height * 3 * sizeof(unsigned char));
	cudaMalloc((void**)&d_color, 3 * sizeof(unsigned char));

	cudaMemcpy(d_pixels, pixels, width * height * 3 * sizeof(unsigned char), cudaMemcpyHostToDevice);
	cudaMemcpy(d_color, color, 3 * sizeof(unsigned char), cudaMemcpyHostToDevice);

	int blockSize = 256;
	int numBlocks = (width * height + blockSize - 1) / blockSize;
    color_detection_kernel << <numBlocks, blockSize >> > (width, height, d_pixels, d_result, d_color);

	cudaMemcpy(result, d_result, width * height * 3 * sizeof(unsigned char), cudaMemcpyDeviceToHost);

	cudaFree(d_pixels);
	cudaFree(d_color);
	cudaFree(d_result);
}