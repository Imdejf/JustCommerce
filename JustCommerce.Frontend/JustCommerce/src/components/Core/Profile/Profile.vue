<template>
<ConfigurationModal
  :title="'ProductTypeTest'"
  :onLoad="onLoad"
  :onSave="onSave">
  <div>
    dwadwawd
  </div>
  </ConfigurationModal>
</template>

<script>
export default {
  methods: {
    onLoad: async function () {
      console.log('dwa')
    }
  },
  mounted: function () {
    alert()
  }
}
</script>
