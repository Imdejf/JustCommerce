import axios from 'axios'
import cookie from 'vue-cookies'

axios.defaults.baseURL = process.env.VUE_APP_API_URL
axios.defaults.headers.common.Authorization = cookie.get('Authorization')
axios.defaults.headers.post['Content-Type'] = 'application/json'
