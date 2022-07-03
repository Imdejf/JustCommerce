import LeftMenu from '@/components/Core/Menu/LeftMenu/LeftMenu.vue'
import TopBar from '@/components/Core/TopBar/TopBar.vue'

//  components
import AdministrationDashboard from '@/components/Administration/Dashboard/Dashboard.vue'
import AdministrationProduct from '@/components/Administration/AdministrationGrid/Product/Product.vue'
import AdministrationProductType from '@/components/Administration/AdministrationGrid/ProductType/ProductType.vue'
import Profile from '@/components/Core/Profile/Profile.vue'

import administrationAdditionalComponents from './AdministrationAdditionalComponents'

const components = {
  LeftMenu,
  TopBar,
  AdministrationDashboard,
  AdministrationProduct,
  AdministrationProductType,
  Profile
}

Object.keys(administrationAdditionalComponents).forEach(x => {
  components[x] = administrationAdditionalComponents[x]
})

export default {
  components: components,
  data () {
    return {
      userInfo: null,
      currentTabComponent: 'AdministrationDashboard',
      menu: [
        {
          groupCode: 'DASHBOARD',
          name: 'DASHBOARD',
          Text: 'Dashboard',
          Icon: 'fa fa-desktop',
          TargetId: 'administration-dashboard',
          InnerElements: []
        },
        {
          groupCode: 'CATALOG',
          name: 'CATALOG',
          Text: 'Catalog',
          Icon: 'fa fa-book',
          InnerElements: [
            {
              Text: 'Products',
              Icon: 'fa fa-cube',
              TargetId: 'administration-product'
            },
            {
              Text: 'Categories',
              Icon: 'fa fa-list',
              TargetId: 'administration-category'
            },
            {
              Text: 'Product Type',
              Icon: 'fa fa-flag',
              TargetId: 'administration-product-type'
            },
            {
              Text: 'Manufacturers',
              Icon: 'fa fa-industry',
              TargetId: 'administration-manufacturers'
            },
            {
              Text: 'Product reviews',
              Icon: 'fa fa-star',
              TargetId: 'administration-product-review'
            },
            {
              Text: 'Product tags',
              Icon: 'fa fa-tag',
              TargetId: 'administration-product-tag'
            }
          ]
        }
      ]
    }
  },
  methods: {
    onClickChild (value) {
      this.currentTabComponent = value // someValue
    }
  },
  created: async function () {
    await this.$store.dispatch('application/setUserInfo')
    this.userInfo = this.$store.state.application.userInfo
  }
}
