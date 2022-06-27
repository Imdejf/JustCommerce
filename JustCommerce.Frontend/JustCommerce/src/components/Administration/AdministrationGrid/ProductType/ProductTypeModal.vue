<template>
  <ConfigurationModal
    :title="'ProductType'"
    :onLoad="onLoad"
    v-model:onSave="onSave"
    :tabs="tabs"
    :validation="v$.model"
    v-model:currentTabId="currentTabId"
  >
  <template #productType>
  <div class="col-md-5">
    <!-- <DsTextInput :label="'Nazwa'" v-model:value.sync="v$.model.name.$model" :validation="v$.model.name"></DsTextInput>
    <DsTextArea :label="'Opis'"></DsTextArea> -->
  </div>
  </template>
  <template #productTypeProperty>
      <div class="row">
        <div class="col-md-3 sidebar-in-tab p-4">
          <!-- <DsDraggableList title="Filtered fields" :callback="doSomething" :addEmpty="addField" :list="model.productTypeProperty" :selected="fieldsChangeOption" :selectedItem="currentField.field" :validations="v$.model.productTypeProperty">
              <template #item-name="{ item }">{{ item.name }}</template>
              <template #item-buttons="{ item }">
                <span
                  class="rs-list-group-item__icon"
                  @click="fieldsCloneOption(item)"
                  v-tooltip:top="'Clone'"
                >
                  <i class="far fa-clone"></i>
                </span>
                <span
                  class="rs-list-group-item__icon ml-2"
                  @click="fieldsDeleteOption(item)"
                  v-tooltip:top="'Delete'"
                >f
                  <i class="far fa-trash-alt"></i>
                </span>
              </template>
          </DsDraggableList> -->
        </div>
        <div class="col-md-9" v-if="currentField.field && currentField.validation">
          <h3 class="section-title">Product types</h3>
          <div class="row">
            <div class="col-md-6">
              <a>dwadwadwad</a>
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
      productTypeProperty: {
        $each: {
          name: { }
        }
      },
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
      productTypeProperty: {
        $each: {
          name: { }
        }
      }
    }
  },
  mehtods: {
    parentMethod () {
      alert('dupa')
    },
    onLoad: async function () {
      alert('load')
      const baseUrl = 'administration/product-types/'
      let structure
      let response
      if (this.context.isEditMode()) {
        response = await this.$axios.$get(baseUrl + this.context.id)
        this.model = response.data
      } else {
        alert('DUPA')
        structure = {
          data: {
            productTypePropertyDetail: []
          }
        }
        response = structure.data
        this.model = response
      }
      this.langs = this.$store.state.appModule.appModule.activeLanguages
      const langsFields = []
      const productTypePropertyDetailList = []
      const productTypePropertyDetailLangsList = []
      this.langs.forEach(lang => {
        let productTypeDetail = response.data.productTypeDetail.find(e => e.langIsoCode === lang.value)
        if (!productTypeDetail) {
          productTypeDetail = {
            langIsoCode: lang.value,
            languageName: lang.text,
            name: '',
            urlName: '',
            description: ''
          }
        }
        let productTypePropertyDetail = response.data.productTypePropertyDetail.find(e => e.langIsoCode === lang.value)
        if (!productTypePropertyDetail) {
          productTypePropertyDetail = {
            active: false,
            allowNull: false,
            productTypeFieldLangs: []
          }
        }

        langsFields.push(productTypeDetail)
        productTypePropertyDetailList.push(productTypePropertyDetail)
        const productTypePropertyDetailLangList = response.data.productTypePropertyDetail[0].productTypeFieldLangs.find(e => e.langIsoCode === lang.value)

        if (productTypePropertyDetailLangList) {
          productTypePropertyDetailLangsList.push(productTypePropertyDetailLangList)
        }
      })
      this.model.productTypeDetail = langsFields
      this.model.productTypePropertyDetail = productTypePropertyDetailList
      this.model.productTypePropertyDetail[0].productTypeFieldLangs = productTypePropertyDetailLangsList
      console.log(this.model)
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
      this.currentField.field = option
      const v = this.$v.productTypePropertyDetail.$each[key]
      this.currentField.validation = v
    },
    addField () {
      const newField = {
        name: ''
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
