<template>
  <div class="current-component">
    <div
      class="h-100 d-flex flex-column"
      :class="targetConfig.fullContainerWidth ? 'container-fluid' : 'container'"
    >
      <div class="card rs-card--height-100 u-border-top">
        <div class="card-header rs-card__header p-0 grid-stack-item-content">
          <slot name="header">
            <h5 class="card-title d-inlibe-block px-4 py-3 m-0">{{ targetConfig.title }}</h5>
          </slot>
        </div>
        <div class="rs-card__body-outer">
          <tabs-management
            :tabs="targetConfig.tabs"
            :currentTabId="targetConfig.currentTabId"
            @tabChanged="tabChanged"
          ></tabs-management>
          <div class="card-body flex-grow-1 u-scrollbar-y d-flex p-0">
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
      return 'ss-loader-target-without-container-wrapper'
    }
  },
  mounted: function () {}
}
</script>
