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
    },
  },
  plugins: [
    require('tailwindcss-gradients'),
  ],
};
