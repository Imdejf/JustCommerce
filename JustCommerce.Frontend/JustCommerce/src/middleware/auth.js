import VueCookies from 'vue-cookies'

export default function auth ({ next, router }) {
  if (!VueCookies.get('Authorization')) {
    return router.push({ name: 'login' })
  }

  return next()
}
