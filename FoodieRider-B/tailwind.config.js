/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './**/*.html',
        './**/*.razor'
    ],
    theme: {
        backgroundColor: theme => ({
            ...theme('colors'),
            'primary': '#7255E9',
            'secondary': '#ffed4a',
            'danger': '#e3342f',
        }),
        extend: {}
    },
    darkMode: false,
    variants: {
        extend: {},
    },
    plugins: [],
}

