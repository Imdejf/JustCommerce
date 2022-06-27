<template>
  <div class="tabs-header" v-if="tabs">
    <div class="card-header bg-transparent">
      <ul class="nav nav-tabs rs-nav-tabs" role="tablist">
        <li
          v-for="tab in tabs"
          :key="tab.id"
          class="nav-item rs-nav-tabs__li p-0"
          @click="changeTab($event, tab)"
        >
          <a
            class="nav-link rs-nav-tabs__link"
            :class="{
              active: tab.id === currentTabId,
              'rs-nav-tabs__link--error': !isTabValid(tab)
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
</template>

<script>
export default {
  props: {
    tabs: {
      type: Array,
      required: false,
      default: null
    },
    currentTabId: {
      type: String,
      required: false,
      default: null
    }
  },
  methods: {
    changeTab: function (e, tab) {
      e.preventDefault()
      this.$emit('tabChanged', tab.id)
    },
    isTabValid: function (tab) {
      if (!tab.validations) {
        return true
      }

      return tab.validations.every(v => !v.$invalid)
    }
  }
}
</script>
