<template>
    <nav class="side-nav">
        <a class="router-link-active intro-x flex items-center pl-5 pt-4">
            <img class="w-6" src="@/assets/logo.9a88cec5.svg"/>
            <span class="hidden xl:block text-white text-lg ml-3">  Rubick </span>
        </a>
        <div class="side-nav__devider my-6"></div>
        <ul>
            <li v-for="(menuItem, index) in menu" v-bind:key="index" @click="expandMenu(index); isActive(menuItem.TargetId ? menuItem.TargetId : null )">
                <BButton class="side-menu" :class="{ 'side-menu--active': activeMenu === index }" style="padding:0; width:100%" v-b-tooltip.hover.right :title="menuItem.Text">
                  <a class="side-menu">
                      <div class="side-menu__icon">
                          <i v-bind:class="menuItem.Icon"></i>
                      </div>
                      <div class="side-menu__title">
                          {{ menuItem.Text }}
                          <div class="side-menu__sub-icon transform rotate-180">
                              <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide">
                                  <polyline points="6 9 12 15 18 9"></polyline>
                              </svg>
                          </div>
                      </div>
                  </a>
                </BButton>
                <ul v-show="expandIndex === index">
                    <li v-for="(menuInnerItem, index) in menuItem.InnerElements" v-bind:key="index" @click="isActive(menuInnerItem.TargetId)">
                        <BButton class="side-menu" :class="{ 'side-menu--active': activeMenu === index }" style="padding:0; width:100%" v-b-tooltip.hover.right :title="menuInnerItem.Text">
                          <a class="side-menu side-menu--active">
                              <div class="side-menu__icon">
                                  <i v-bind:class="menuInnerItem.Icon"></i>
                              </div>
                              <div class="side-menu__title">
                                  {{ menuInnerItem.Text }}
                                  <!---->
                              </div>
                          </a>
                        </BButton>
                    </li>
                </ul>
            </li>
        </ul>
    </nav>
</template>

<script>

export default {
  props: ['menu'],
  data () {
    return {
      expandIndex: null,
      activeIndex: null,
      activeMenu: 0
    }
  },
  methods: {
    expandMenu (index) {
      if (index !== this.expandIndex) {
        this.expandIndex = index
        console.log(this.expandIndex)
      } else {
        this.expandIndex = null
      }
    },
    selectMenu (index) {
      if (index !== this.activeMenu) {
        this.activeMenu = index
        console.log(this.activeMenu)
      } else {
        this.activeMenu = null
      }
    },
    isActive (name) {
      if (name !== null) {
        this.$emit('isActive', name)
      }
    }
  }
}
</script>
