<template>
    <ConfigurationGrid ref="grid" :gridConfig="gridConfig" :toolbarGridButtons="toolbarGridConfig">
    </ConfigurationGrid>
    <product-type-modal-test  v-if="modalWindow" :context="context" @close="onClose"></product-type-modal-test>
</template>

<script>
import ProductTypeModalTest from '@/components/Administration/AdministrationGrid/ProductType/ProductTypeModalTest'

export default {
  components: {
    ProductTypeModalTest
  },
  data: function () {
    return {
      modalWindow: false,
      context: null
    }
  },
  computed: {
    gridConfig: function () {
      return {
        uid: 'administration-product-type',
        url: '/administration/producttype',
        columns: [
          {
            columnName: 'Id',
            caption: 'Id',
            columnType: 'text',
            horizontalAlign: '',
            backcolor: null,
            backcolorColumn: null,
            textcolor: null,
            textcolorColumn: null,
            defaultFilterType: '',
            dataFormatingString: '',
            width: 140,
            bold: true,
            defaultKey: false
          },
          {
            columnName: 'Name',
            caption: 'Name',
            columnType: 'text',
            horizontalAlign: '',
            backcolor: null,
            backcolorColumn: null,
            textcolor: null,
            textcolorColumn: null,
            defaultFilterType: '',
            dataFormatingString: '',
            width: 400,
            bold: true,
            defaultKey: false
          },
          {
            columnName: 'langs[0].name',
            caption: 'Name',
            columnType: 'text',
            horizontalAlign: '',
            backcolor: null,
            backcolorColumn: null,
            textcolor: null,
            textcolorColumn: null,
            defaultFilterType: '',
            dataFormatingString: '',
            width: 400,
            bold: true,
            defaultKey: false
          },
          {
            columnName: 'langs[0].urlName',
            caption: 'Url name',
            columnType: 'text',
            horizontalAlign: '',
            backcolor: null,
            backcolorColumn: null,
            textcolor: null,
            textcolorColumn: null,
            defaultFilterType: '',
            dataFormatingString: '',
            width: 400,
            bold: true,
            defaultKey: false
          }
        ]
      }
    },
    toolbarGridConfig: function () {
      return [
        this.$checkConfiguration.ToolbarItems.handler.add(this, this.addElement),
        this.$checkConfiguration.ToolbarItems.handler.edit(this, this.editElement),
        this.$checkConfiguration.ToolbarItems.handler.delete(this, this.deleteElement),
        this.$checkConfiguration.ToolbarItems.handler.copy(this, this.copyElement)
      ]
    }
  },
  methods: {
    addElement: function (context) {
      this.context = context
      this.context.setAddMode()
      this.modalWindow = true
    },
    editElement: function (context) {
      this.context = context
      this.context.setEditMode()
      this.modalWindow = true
    },
    onClose: function () {
      this.modalWindow = false
      this.context = null
      // this.$refs.grid.refresh()
    }
  }
}
</script>
