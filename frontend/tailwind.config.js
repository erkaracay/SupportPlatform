module.exports = {
  content: [
    './index.html',
    './src/**/*.{vue,js,ts,jsx,tsx}',
  ],
  darkMode: 'class',
  theme: {
    extend: {
      colors: {
        primary: '#F59E0B',       // amber-500
        primaryLight: '#FEF3C7',  // amber-100
        text: '#18181B',          // zinc-900
        surface: '#F1F5F9',       // zinc-100
        darkBg: '#18181B',        // dark mode background
        darkText: '#E5E7EB'       // text for dark mode
      }
    }
  },
  plugins: []
}
