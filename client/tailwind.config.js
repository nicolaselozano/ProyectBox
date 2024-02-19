/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,js,ts,tsx}"],
  theme: {
    extend: {
      backgroundColor: {
        "general_bg": 'rgba(34, 28, 41, 1)', 
        "cards_bg": "rgba(0, 0, 0, 1)",
      },
      borderColor : {
        "cards_border": "rgba(148, 87, 235, 1)",
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
  ],
};
