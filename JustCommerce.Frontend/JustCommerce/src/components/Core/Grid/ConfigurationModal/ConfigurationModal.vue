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
          <loading v-model:active="isLoading"
                  :can-cancel="false"
                  :is-full-page="false"
                  :height="150"
                  :width="150"
                  :background-color="'gray'"
                  :opacity="0.2"
                  :color="'#F49828'"
                  />
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
          <div class="modal-footer" v-show="!isLoading">
            <div class="mr-auto" v-if="isSystemObject && !hasSystemAccess && !allowSystemEdit">
              <p class="alert alert-danger mb-0">
                You can not modify system objects on this instance.
              </p>
            </div>
            <div class="button-area" v-if="isReadOnly && !allowSystemEdit">
              <button class="btn btn-light" @click="close">Close</button>
            </div>
            <div class="button-area" v-else>
              <button class="btn btn-light" @click="close">Cancel</button>
              <button class="btn btn-primary" @click="save">Save</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Loading from 'vue-loading-overlay'
import 'vue-loading-overlay/dist/vue-loading.css'

export default {
  props: {
    method: { type: Function },
    title: {
      type: String,
      required: true
    },
    validation: {
      required: true
    },
    onSave: {
      type: Function,
      required: true
    },
    onLoad: {
      type: Function,
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
  components: {
    Loading
  },
  data: function () {
    return {
      isReady: false,
      isLoading: true,
      fullPage: true
    }
  },
  methods: {
    save: function () {
      this.validation.$reset()
      this.validation.$touch()
      if (this.validation.$invalid) {
        return
      }
      this.isLoading = true
      this.onSave()

        .then(() => {
          this.close()
        })
        .catch(() => {
          this.isLoading = false

          this.$toast.error('Server error.')
        })
    },
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
  },
  mounted: async function () {
    if (this.tabs.length === 0) {
      throw new Error('Modal can not have 0 tabs.')
    }
    try {
      this.isLoading = true
      await this.onLoad()
      this.isReady = true
      this.isLoading = false
    } catch (error) {
      console.log(error)
      this.onClose()
      this.$toast.error('Server error.')
    }
  }
}
</script>
