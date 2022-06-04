import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import { library } from '@fortawesome/fontawesome-svg-core'
import { faArrowRight } from '@fortawesome/free-solid-svg-icons'
import { faFacebook, faTwitter, faGoogle } from '@fortawesome/free-brands-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import VueCookies from 'vue-cookies'
import axios from 'axios'
import VueAxios from 'vue-axios'
import '@/plugins/axios'
import '@/assets/scss/main.scss'

import Loading from './components/Core/Loading/Loading.vue'

library.add(faArrowRight)
library.add(faFacebook)
library.add(faTwitter)
library.add(faGoogle)

const app = createApp(App)

// Font-Awesome
app.component('font-awesome-icon', FontAwesomeIcon)

app.component('Loader', Loading)
app.use(VueCookies)
app.use(VueAxios, axios)
app.use(router)
app.use(store)
app.mount('#app')
