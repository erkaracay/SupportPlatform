import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import tailwindConfig from './tailwind.config'

// https://vite.dev/config/
export default defineConfig({
  plugins: [vue(), tailwindConfig],
})
