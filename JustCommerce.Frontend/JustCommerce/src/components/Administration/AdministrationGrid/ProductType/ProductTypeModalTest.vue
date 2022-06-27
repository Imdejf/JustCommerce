<template>
  <ConfigurationModal
  :title="'ProductTypeTest'"
  :onLoad="onLoad"
  :onSave="onSave"
  :tabs="tabs"
  :validation="v$.model"
  v-model:currentTabId="currentTabId">
  <template #productType>
  <div class="col-md-5">
    <DsTextInput :label="'Nazwa'" v-model:value="v$.model.name.$model" :validation="v$.model.name"></DsTextInput>
    <DsTextArea :label="'Opis'"></DsTextArea>
  </div>
  </template>
  <template #productTypeProperty>
      <div class="row">
        <div class="col-md-3 sidebar-in-tab p-4">
          <DsDraggableList title="Filtered fields" :addEmpty="addField" :list="model.productTypeProperty" :selected="fieldsChangeOption" :selectedItem="currentField.field" :validations="v$.model.productTypeProperty">
              <template #item-buttons="{ item }">
                <span
                  class="rs-list-group-item__icon px-2"
                  @click="fieldsCloneOption(item)"
                >
                  <i class="fa fa-clone"></i>
                </span>
                <span
                  class="rs-list-group-item__icon"
                  @click="fieldsDeleteOption(item)"
                >
                  <i class="fa fa-trash"></i>
                </span>
              </template>
          </DsDraggableList>
        </div>
        <div class="col-md-9" v-if="currentField.field && currentField.validation">
          <h3 class="section-title">Product types</h3>
          <div class="row">
            <div class="col-md-6">
              <DsTextInput
              :label="'Nazwa'"
              v-model:value="currentField.field.name"></DsTextInput>
              <DsNumberInput
              :label="'Kolejność'"
              v-model:value="currentField.field.orderValue"
              :decimalDigits="1"
              :allowNull="false"
              :spinButtons="true">
              </DsNumberInput>
              <DsTextArea
              :label="'Opis'"
              v-model:value="currentField.field.description">
              </DsTextArea>
              <DsNumberInput
              :label="'Maksymalna długość'"
              v-model:value="currentField.field.maxValue"
              :decimalDigits="1"
              :allowNull="false"
              :spinButtons="true">
              </DsNumberInput>
              <DsNumberInput
              :label="'Minimalna długość'"
              v-model:value="currentField.field.minValue"
              :decimalDigits="1"
              :allowNull="false"
              :spinButtons="true">
              </DsNumberInput>
            </div>
            <div class="col-md-4">
              <DsApiDropDown
              :label="'Typ danych'"
              ></DsApiDropDown>
              <DsCheckBox
              :label="'Aktywne'"
              v-model:value="currentField.field.active"
              ></DsCheckBox>
              <DsCheckBox
              :label="'Zezwalaj na brak wartości'"
              v-model:value="currentField.field.defaultValue"
              ></DsCheckBox>
            </div>
          </div>
        </div>
      </div>
  </template>
  </ConfigurationModal>
</template>

<script>
import useVuelidate from '@vuelidate/core'
import { required } from '@vuelidate/validators'

export default {
  props: ['context'],
  components: {
  },
  data: function () {
    return {
      v$: useVuelidate(),
      model: [],
      activeDirectoryDataset: [],
      currentField: {
        field: null,
        validation: null
      },
      currentTabId: 'productType'
    }
  },
  validations: {
    model: {
      name: { required },
      description: { },
      productTypeProperty: {
        each: {
          name: { },
          orderValue: { },
          description: { },
          active: { },
          defaultValue: { },
          minValue: { },
          maxValue: { }
        }
      }
    }
  },
  methods: {
    onLoad: async function () {
      const item = {
        name: '',
        productTypeProperty: []
      }
      this.model = item
    },
    onSave: async function () {
      let request
      const baseUrl = 'administration/product-types'
      this.$helpers.toggleComponentLoader(true, this)
      if (this.context.isEditMode()) {
        request = await this.$axios.$put(baseUrl, this.model)
      } else {
        request = await this.$axios.$post(baseUrl, this.model)
      }
      await request
    },
    fieldsChangeOption: function (option, key) {
      this.currentField.field = option.element
      const v = this.v$.model.productTypeProperty.each[key]
      this.currentField.validation = v
      console.log(this.currentField)
    },
    addField () {
      const newField = {
        name: '',
        orderValue: 1,
        description: '',
        active: true,
        defaultValue: false,
        minValue: 0,
        maxValue: 0
      }
      this.model.productTypeProperty.push(newField)
    }
  },
  computed: {
    tabs: function () {
      const tabs = [
        {
          id: 'productType',
          name: 'PRODUCT TYPE',
          validation: model => []
        },
        {
          id: 'productTypeProperty',
          name: 'PRODUCT TYPE PROPERTY',
          validation: model => []
        }
      ]
      return tabs
    }
  }
}
</script>
