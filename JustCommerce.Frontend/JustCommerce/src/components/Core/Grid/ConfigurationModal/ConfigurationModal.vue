<template>
  <div class="x-ss-modal">
    <div class="modal fade show" style="display: block">
      <div class="modal-dialog modal-dialog-centered modal-xxl">
        <div class="modal-content u-scrollbar-y">
          <div class="modal-header">
            <h5 class="modal-title">{{ title }}</h5>
            <button
              @click="close"
              type="button"
              class="close"
            >
              <span>×</span>
            </button>
          </div>
          <div class="tabs-header" v-show="!isLoading && isReady && tabs.length > 1">
            <div class="card-header bg-transparent">
              <ul class="nav nav-tabs ds-nav-tabs" role="tablist">
                <li
                  v-for="tab in tabs"
                  :key="tab.id"
                  class="nav-item ds-nav-tabs__li p-0"
                  @click="changeTab($event, tab)"
                >
                  <a
                    class="nav-link ds-nav-tabs__link"
                    :class="{
                      active: tab.id === currentTabId,
                      'ds-nav-tabs__link--error': !isTabValid(tab)
                    }"
                    href="#"
                  >
                    {{ tab.name }}
                    <i v-if="!isTabValid(tab)" class="fas fa-triangle fa-sm u-font-red ml-2"></i>
                  </a>
                </li>
              </ul>
            </div>
          </div>
          <div class="modal-body u-scrollbar-y">
            <div class="w-100" v-if="isMultiTab">
              <div
                v-for="tab in tabs"
                :key="tab.id"
                v-show="!isLoading && isReady && isCurrentTab(tab)"
              >
                <div class="container-fluid" v-if="isReady">
                  <slot :name="tab.id">
                    <h1 class="section-title">{{ tab.name }}</h1>
                  </slot>
                </div>
              </div>
            </div>
            <div class="w-100" v-else>
              <div class="container-fluid" v-if="isReady" v-show="!isLoading">
                <slot :name="tabs[0].id">
                  <h5 class="section-title">{{ tabs[0].name }}</h5>
                </slot>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    title: {
      type: String,
      required: true
    },
    validation: {
      required: true
    },
    onClose: {
      type: Function,
      required: false,
      default: context => context.$emit('close')
    },
    tabs: {
      required: false,
      default: () => [
        {
          id: null,
          name: 'Default',
          validation: model => []
        }
      ]
    },
    currentTabId: {
      required: false,
      default: null
    }
  },
  data: function () {
    return {
      isLoading: false,
      isReady: true
    }
  },
  methods: {
    close: function () {
      this.onClose(this.$parent)
    },
    changeTab: function (e, tab) {
      e.preventDefault()
      this.$emit('update:currentTabId', tab.id)
    },
    isCurrentTab: function (tab) {
      return this.currentTabId === tab.id
    },
    isTabValid: function (tab) {
      const validations = tab.validation(this.validation)
      const isValid = this.checkTab(validations)
      return isValid
    },
    checkTab: function (validations) {
      for (let i = 0; i < validations.length; i++) {
        if (validations[i].$anyError) {
          return false
        }
      }

      return true
    }
  },
  computed: {
    isMultiTab: function () {
      return this.tabs.length > 1
    }
  }
}
</script>
