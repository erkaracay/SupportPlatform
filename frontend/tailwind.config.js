module.exports = {
  content: [
    "./index.html",
    "./src/**/*.{vue,js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        primary: '#4F46E5',       // indigo-600
        primaryLight: '#E0E7FF',  // indigo-100
        danger: '#F43F5E',        // rose-500
        warning: '#F59E0B',       // amber-500
        success: '#10B981',       // emerald-500
        info: '#3B82F6',          // blue-500
        dark: '#1F2937',          // gray-800
        light: '#F9FAFB'          // gray-50
      }
    },
  },
  plugins: [],
}
