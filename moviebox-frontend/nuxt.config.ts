// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  future: {
    compatibilityVersion: 4
  },
  compatibilityDate: '2024-11-01',
  devtools: { enabled: true },

  modules: [
    '@nuxt/eslint',
    '@nuxt/fonts',
    '@nuxt/icon',
    '@nuxt/test-utils',
    '@nuxt/ui-pro'
  ],
  css: ['~/assets/css/main.css'],
  vite: {
    server: {
      proxy: {
        '/api': {
          target: 'http://localhost:5224',
        }
      }
    }
  }
})
