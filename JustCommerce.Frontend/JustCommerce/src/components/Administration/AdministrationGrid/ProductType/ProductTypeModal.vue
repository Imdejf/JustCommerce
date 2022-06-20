<template>
  <ConfigurationModal
    :title="'ProductType'"
    :onLoad="onLoad"
    :onSave="onSave"
    :tabs="tabs"
    :validation="v$.model"
    v-bind:currentTabId="currentTabId"
  >
  <template #basic>
  <div class="col-md-5">
    <DsTextInput :label="'Nazwa'" v-model:value.sync="v$.model.name.$model" :validation="v$.model.name"></DsTextInput>
    <DsTextArea :label="'Opis'"></DsTextArea>
  </div>
  </template>
  </ConfigurationModal>
</template>

<script>
import useVuelidate from '@vuelidate/core'
import { required } from '@vuelidate/validators'
const tabList = [
  {
    name: 'productType',
    text: 'ManagmentProduct.ProductTypes.ProductType',
    loaded: true
  }
]

export default {
  props: ['context'],
  components: {
  },
  setup () {
    return { v$: useVuelidate() }
  },
  data: function () {
    return {
      model: {
        name: ''
      },
      currentTabId: 'basic',
      selectedTab: tabList[0]
    }
  },
  validations: {
    model: {
      name: { required }
    }
  },
  mehtods: {
    onLoad: async function () {
      alert('load')
    },
    changeTab: function (e, tab) {
      e.preventDefault()
      this.selectedTab = tab
    }
  },
  computed: {
    tabs: function () {
      const tabs = [
        {
          id: 'basic',
          name: 'BASIC',
          validation: model => []
        }
      ]
      return tabs
    }
  }
}
</script>
