import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import '@/plugins/axios'

import '@/assets/scss/main.scss'

import Loading from './components/Core/Loading/Loading.vue'

const app = createApp(App)

app.component('Loader', Loading)

app.use(router)
app.use(store)
app.mount('#app')
