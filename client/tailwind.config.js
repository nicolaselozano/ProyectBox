/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,js,ts,tsx}",
    "./node_modules/flowbite-react/lib/**/*.js"
  ],
  theme: {
    extend: {
      colors: {
        darkPurple: {
          50: '#f8f5ff',
          100: '#ebe1ff',
          200: '#d5baff',
          300: '#bb8aff',
          400: '#9e5fff',
          500: '#7b30ff',
          600: '#611adf',
          700: '#4a13a6',
          800: '#340c7b',
          900: '#23064d',
        },
      },
      fontFamily: {
        'russo': ['Russo One', 'sans-serif'],
      },
      backgroundColor: {
        "general_bg": 'rgba(34, 28, 41, 1)', 
        "cards_bg": "rgba(0, 0, 0, 1)",
      },
      borderColor : {
        "cards_border": "rgba(148, 87, 235, 1)",
        "profile_border": "rgba(0, 0, 0, 1)",
      },
      gradientColorStops: {
        "general_bg": 'rgba(34, 28, 41, 1)', 
        "cards_bg": "rgba(0, 0, 0, 1)", 
      },
      //animacion para textos
      textColor: {
        "violet_text": "rgba(148, 87, 235, 1)",
      },
      keyframes: {
        shine: {
          '0%, 100%': { opacity: 1 },
          '50%': { opacity: 0.5 },
        },
        borde_shine: {
          '0%, 100%': { borderColor: 'rgba(148, 87, 235, 1)' },
          '50%': { borderColor: 'rgba(148, 87, 235, 0.5)' },
        },
      },
      animation: {
        shine: 'shine 20s infinite', 
        borde_shine: 'borde_shine 2s infinite', 
      },
    },
  },
  plugins: [
    require('tailwindcss-gradients'),
    require("flowbite/plugin")
  ],
};
