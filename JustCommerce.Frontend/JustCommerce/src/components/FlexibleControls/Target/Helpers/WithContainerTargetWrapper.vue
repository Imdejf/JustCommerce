<template>
  <div class="current-component">
    <div class="h-100" :class="targetConfig.fullContainerWidth ? 'container-fluid' : 'container'">
      <div class="card rs-card rs-card--height-100 u-border-top">
        <transition name="fade">
        </transition>
        <div class="card-header rs-card__header">
          <slot name="header">
            <h5 class="card-title">{{ targetConfig.title }}</h5>
          </slot>
        </div>
        <div class="rs-card__body-outer">
          <tabs-management
            :tabs="targetConfig.tabs"
            :currentTabId="targetConfig.currentTabId"
            @tabChanged="tabChanged"
          ></tabs-management>
          <div class="card-body rs-card__body u-scrollbar-y">
            <slot name="content" v-if="!targetConfig.useTabs"> </slot>
            <div v-for="tab in targetConfig.tabs" :key="tab.id" v-else v-show="isCurrentTab(tab)">
              <slot :name="tab.id"></slot>
            </div>
          </div>
          <div class="card-footer rs-card__footer" v-if="hasFooter">
            <slot name="footer"> </slot>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import WrapperMixin from './WrapperMixin.js'
import TabsManagement from './TabsManagement.vue'

export default {
  components: {
    TabsManagement
  },
  mixins: [WrapperMixin],
  data: function () {
    return {
      loaded: false
    }
  },
  computed: {
    loaderClass: function () {
      return 'ss-loader-target-with-container-wrapper'
    }
  },
  mounted: function () {}
}
</script>
