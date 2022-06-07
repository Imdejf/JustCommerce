<template>
    <ConfigurationGrid ref="grid" :gridConfig="gridConfig" :toolbarGridButtons="toolbarGridConfig">
    </ConfigurationGrid>
</template>

<script>
export default {
  data: function () {
    return {
    }
  },
  computed: {
    gridConfig: function () {
      return {
        uid: 'administration-category',
        url: 'administration/category',
        columns: [
          {
            columnName: 'orderView',
            caption: 'Order view',
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
            columnName: 'photo',
            caption: 'Photo',
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
  }
}
</script>
