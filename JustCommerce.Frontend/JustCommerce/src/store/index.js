import { createStore } from 'vuex'

import AuthModule from './modules/auth'
import ApplicationModule from './modules/application'

export default createStore({
  strict: true,
  modules: {
    auth: AuthModule,
    application: ApplicationModule
  },
  state: {
  },
  getters: {
  },
  mutations: {
  },
  actions: {
  }
})
