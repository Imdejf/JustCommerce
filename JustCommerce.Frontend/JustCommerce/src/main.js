import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import { library } from '@fortawesome/fontawesome-svg-core'
import { faArrowRight, faDashboard, faDesktop } from '@fortawesome/free-solid-svg-icons'
import { faFacebook, faTwitter, faGoogle } from '@fortawesome/free-brands-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import VueCookies from 'vue-cookies'
import axios from 'axios'
import VueAxios from 'vue-axios'
import BootstrapVue3 from 'bootstrap-vue-3'
import 'devextreme/dist/css/dx.light.css'
import '@/plugins/axios'
import 'font-awesome/scss/font-awesome.scss'
import '@/assets/scss/main.scss'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue-3/dist/bootstrap-vue-3.css'
import toast from './plugins/toast.js'
import i18n from './plugins/i18n.js'

import Loading from './components/Core/Loading/Loading.vue'
import ConfigurationGrid from '@/components/Core/Grid/ConfigurationGrid/ConfigurationGrid'
import ConfigurationModal from '@/components/Core/Grid/ConfigurationModal/ConfigurationModal'
import ToolbarItemsClass from '@/components/Core/Grid/ToolbarItems.js'

// FlexibleControls
import DsTextInput from '@/components/FlexibleControls/TextInput/TextInput.vue'
import DsTextArea from '@/components/FlexibleControls/TextArea/TextArea.vue'
import DsDraggableList from '@/components/FlexibleControls/DraggableList/DraggableList.vue'
import DsNumberInput from '@/components/FlexibleControls/NumberInput/NumberInput.vue'
import DsCheckBox from '@/components/FlexibleControls/CheckBox/CheckBox.vue'
import DsDropDown from '@/components/FlexibleControls/DropDown/DropDown.vue'

// Import the CSS or use your own!
import 'vue-toastification/dist/index.css'

library.add(faDashboard)
library.add(faArrowRight)
library.add(faDesktop)
library.add(faFacebook)
library.add(faTwitter)
library.add(faGoogle)

const app = createApp(App)

// Font-Awesome
app.component('font-awesome-icon', FontAwesomeIcon)
app.component('DsTextInput', DsTextInput)
app.component('DsTextArea', DsTextArea)
app.component('DsDraggableList', DsDraggableList)
app.component('DsNumberInput', DsNumberInput)
app.component('DsCheckBox', DsCheckBox)
app.component('ApiDropDown', DsDropDown)

app.component('Loader', Loading)
app.component('ConfigurationGrid', ConfigurationGrid)
app.component('ConfigurationModal', ConfigurationModal)
app.use(BootstrapVue3)
app.use(VueCookies)
app.use(VueAxios, axios)
app.use(i18n)
app.use(router)
app.use(store)

app.config.globalProperties.$toast = toast
app.config.globalProperties.$checkConfiguration = {
  ToolbarItems: ToolbarItemsClass
}
app.mount('#app')
