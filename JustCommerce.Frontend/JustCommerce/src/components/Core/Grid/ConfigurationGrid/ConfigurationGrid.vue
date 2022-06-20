<template>
  <div style="height:80vh">
    <div class="grid-header">
      <Toolbar :config="$toolbarGridConfig" :selectedRowContext="$selectedRowContext"> </Toolbar>
    </div>
    <Grid ref="grid" :config="$dataGridConfig" :dataSource="$dataSource" @click="$onClick" />
  </div>
</template>

<script>
import Grid from '../Grid.vue'
import Toolbar from '@/components/Core/Toolbar/Toolbar.vue'
import SetParametersModal from '../setParametersModal.js'
import CustomStore from '../CustomStore.js'
import ArrayStore from 'devextreme/data/array_store'

export default {
  components: {
    Grid,
    Toolbar
  },
  props: {
    gridConfig: {
      type: Object, // Object containing uid, columns, url, etc...
      required: true
    },
    toolbarGridButtons: {
      type: Array, // Object array type $configurationHelpers.ToolbarButton
      required: false,
      default: () => []
    }
  },
  data: function () {
    return {
      selectedRow: null
    }
  },
  computed: {
    $dataGridConfig: function () {
      const columns = this.gridConfig.columns.map(e => ({
        name: e.columnName,
        dataField: e.columnName,
        localisation: [
          {
            code: 'en-EN',
            caption: e.caption
          }
        ],
        alignment: e.horizontalAlign.toLowerCase(),
        dataType: (() => {
          switch (e.columnType) {
            case 'checkBox':
              return 'boolean'
            case 'text':
              return 'string'
            case 'number':
              return 'number'
            case 'date':
              return 'date'
            case 'icon':
              return 'icon'
            default:
              return 'string'
          }
        })(),
        fixed: false,
        autoSize: false,
        visible: e.visibled !== false,
        width: e.width,
        key: e.defaultKey,
        bold: e.bold,
        backgroundColor: e.backcolor,
        backgroundColorColumn: e.backcolorColumn,
        textColor: e.textcolor,
        textColorColumn: e.textcolorColumn,
        valueFormatting:
          e.columnType === 'date'
            ? e.dataFormatingString
              ? e.dataFormatingString
              : 'yyy-MM-dd'
            : null,
        tooltipColumn: e.tooltipColumn,
        allowEditing: e.allowEditing ? e.allowEditing : false,
        sortOrder: e.sortOrder
      }))

      return {
        key: this.gridConfig.defaultKey ? this.gridConfig.defaultKey : 'Id',
        columns: columns
      }
    },
    $dataSource: function () {
      if (this.gridConfig.data) {
        return new ArrayStore({
          key: this.gridConfig.key,
          data: this.gridConfig.data
        })
      }
      const store = CustomStore(this.$dataGridConfig.key, this.axios.defaults.baseURL + this.gridConfig.url)
      return store
    },

    $toolbarGridConfig: function () {
      let buttons = this.toolbarGridButtons.map(button => ({
        refno: null,
        name: button.getText(),
        text: button.getText(),
        icon: button.getIcon(),
        additionalIconClass: button.getColorClass(),
        children: [],
        contextRequired: button.isContextRequired(),
        onClick: () => this.$handleToolbarClick(button)
      }))
      const refreshButton = {
        icon: 'fas fa-sync',
        additionalIconClass: 'text-primary',
        onClick: this.refresh,
        text: 'Toolbar.Refresh'
      }

      buttons = [refreshButton, ...buttons]

      return {
        buttons: buttons,
        hamburger: {
          exportToExcel: this.allowHamburger,
          notes: this.allowHamburger,
          files: this.allowHamburger,
          photos: this.allowHamburger,
          attachments: this.allowHamburger,
          simpleDiscussion: this.allowHamburger
        },
        functions: {
          refresh: () => this.$refs.grid.refresh(),
          exportToExcel: this.exportToExcel
        }
      }
    },
    $selectedRowContext: function () {
      return {
        row: {
          isSelected: this.isSelected,
          keyName: this.$dataGridConfig.key,
          key: this.selectedId,
          data: this.isSelected ? this.selectedRow.data : null
        },
        gridParameters: [],
        hiddenColumns: []
      }
    },
    selectedId: function () {
      if (this.selectedRow) {
        return this.selectedRow.key
      } else {
        return null
      }
    },
    isSelected: function () {
      return this.selectedRow && this.selectedRow.key
    }
  },
  methods: {
    $onClick: function (event) {
      this.selectedRow = event
    },
    $handleToolbarClick: function (button) {
      if (button.isContextRequired() && !this.isSelected) {
        // this.$utils.showErrorToast(this.$t('DataGrid.NoRowSelect'), 3000)
        return
      }

      button.invokeOnClick(
        new SetParametersModal({
          id: this.selectedId
        })
      )
    },
    refresh: function () {
      this.$refs.grid.refresh()
    }
  }
}
</script>
