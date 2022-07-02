import axios from 'axios'
import cookies from 'vue-cookies'

export default {
  namespaced: true,
  state: {
    authenticated: false
  },
  mutations: {
    setAuthenticated (state) {
      state.authenticated = true
    }
  },
  actions: {
    async authenticate (context, credentials) {
      const response = await axios.post('/Identity/login', credentials)
      if (response.data.Data.Jwt.length > 10) {
        cookies.set('Authorization', 'bearer' + response.data.Data.Jwt, '1d')
        context.commit('setAuthenticated')
      }
    }
  }
}
