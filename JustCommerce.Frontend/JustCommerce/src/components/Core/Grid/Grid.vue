<template>
  <dx-data-grid
    ref="grid"
    :class="'rs-dx-datagrid'"
    :dataSource="dataSource"
    :onSelectionChanged="$onSelectionChanged"
    :height="'100%'"
    :width="'100%'"
    :columns="$columns"
    :searchPanel="$searchPanel"
    @toolbar-preparing="$onToolbarPreparing"
    :selection="$configuration.selection"
    :pager="$configuration.pager"
    :paging="$configuration.paging"
    :loadPanel="$configuration.loadPanel"
    :filterRow="$configuration.filterRow"
    :sorting="$configuration.sorting"
    :columnFixing="$configuration.fixing"
    :scrolling="$configuration.scrolling"
    :rowAlternationEnabled="true"
    :showBorders="true"
    :focusedRowEnabled="false"
    :wordWrapEnabled="true"
    :showColumnLines="true"
    :showRowLines="true"
    :noDataText="$t('dataGrid.noData')"
    :remoteOperations="useRemoteOperations"
    :allowColumnReordering="true"
    :allowColumnResizing="true"
    :columnResizingMode="'widget'"
    :columnAutoWidth="true"
    :allowHiding="false"
    :onCellPrepared="$onCellPrepared"
    :onRowPrepared="$onRowPrepared"
    :columnMinWidth="0"
    @optionChanged="$optionChanged"
  >
    <template v-for="cell in customCells" :key="cell.type"  v-slot:[cell.type]="{ data }">
      <component :is="cell.component" :rawCellData="data"></component>
    </template>
    <DxEditing
      ref="editmodal"
      :allow-updating="true"
      :edit-column-name="'system'"
      :use-icons="true"
      mode="batch"
    />
  </dx-data-grid>
</template>
<script>
import { DxDataGrid, DxEditing } from 'devextreme-vue/data-grid'
import CustomCells from './CustomCells/CustomCells'
import { filterTypeMap, filterOperationsMap } from './TypeMaps.js'

const getCustomTemplateIfRequired = type => {
  if (CustomCells[type]) {
    return type
  } else {
    return null
  }
}

const valueFormatingNumber = [
  {
    value: 'n',
    text: '#0'
  },
  {
    value: 'd1',
    text: '#0.0'
  },
  {
    value: 'd2',
    text: '#0.00'
  },
  {
    value: 'd3',
    text: '#0.000'
  },
  {
    value: 'd4',
    text: '#0.0000'
  },
  {
    value: 'd5',
    text: '#0.00000'
  },
  {
    value: 'd6',
    text: '#0.000000'
  }
]

export default {
  components: {
    DxEditing,
    DxDataGrid
  },
  props: {
    config: {
      type: Object,
      required: true
    },
    dataSource: {
      type: Object,
      required: true
    },
    useRemoteOperations: {
      type: Boolean,
      required: false,
      default: true
    }
  },
  data: function () {
    return {
      selectedRow: null
    }
  },
  computed: {
    $useCustomRendering: function () {
      return this.config.columns.some(
        e =>
          e.textColor ||
          e.textColorColumn ||
          e.backgroundColor ||
          e.backgroundColorColumn ||
          e.multiline
      )
    },
    $columns: function () {
      const columns = this.config.columns.map(e => {
        let localisation = e.localisation.find(e => e.code === 'en-EN')
        if (!localisation) {
          localisation = e.localisation.find(e => e.code === 'en-EN')
          if (!localisation) {
            localisation = {}
          }
        }

        const customTemplate = getCustomTemplateIfRequired(e.dataType)
        let customTypeOptions = null
        if (customTemplate != null) {
          customTypeOptions = this.customCells.find(e => e.type === customTemplate)
        }

        const customClasses = []

        if (e.bold) {
          customClasses.push('rs-datagrid-custom-bold')
        }
        let format = e.valueFormatting
        if (e.dataType === 'number') {
          valueFormatingNumber.forEach(function (el) {
            if (el.value === e.valueFormatting) {
              format = el.text
            }
          })
        }
        let allowSearch = false
        if (e.name === '_SEARCH_COLUMN') {
          allowSearch = true
        }

        if (e.dataType === 'datetime' && format === 'yyyy-MM-dd HH:mm:ss.fff') {
          format = 'yyyy-MM-dd HH:mm:ss.SSS'
        }
        const column = {
          name: e.name,
          dataField: e.name,
          cellTemplate: customTemplate,
          caption: localisation.caption,
          alignment: e.alignment,
          allowEditing: e.allowEditing ? e.allowEditing : false,
          allowFiltering: e.allowFilter,
          allowSearch: allowSearch,
          dataType: e.dataType,
          fixed: e.fixed,
          fixedPosition: 'left',
          visible: e.visible,
          width: e.autoSize ? 'auto' : e.width,
          minWidth: 20,
          trueText: this.$t('dataGrid.true'),
          falseText: this.$t('dataGrid.false'),
          cssClass: customClasses.join(' '),
          format: format,
          sortOrder: e.sortOrder
        }
        // dodanie typu filtra z konfiguracji
        const filterType = filterTypeMap.find(el => el.text === e.filterType)
        if (filterType) {
          e.filterType = filterType.value
        }

        const filterOperations = filterOperationsMap.find(el => el.type === e.dataType)
        if (filterOperations) {
          column.filterOperations = filterOperations.filterOperators
        }

        if (e.filterType != null) {
          column.selectedFilterOperation = e.filterType
        }

        if (customTypeOptions) {
          column.allowFiltering = customTypeOptions.allowFiltering
          column.filterOperations = customTypeOptions.filterOperations
          column.allowSorting = customTypeOptions.allowSorting

          column.tooltip = e.tooltip
          column.tooltipColumn = e.tooltipColumn
        }
        console.log(column)
        return column
      })
      columns.push({
        cssClass: 'dx-empty-column',
        allowReordering: false,
        allowSearch: false,
        allowSorting: false,
        allowFixing: false,
        width: 0
      })
      return columns
    },
    $searchPanel: function () {
      return {
        visible: this.config.searchPanelVisible,
        placeholder: this.$t('general.search'),
        width: '100%'
      }
    },
    $configuration: function () {
      return {
        selection: {
          mode: 'single'
        },
        pager: {
          visible: true,
          allowedPageSizes: [30, 50, 70],
          showNavigationButtons: true,
          showPageSizeSelector: true,
          showInfo: true,
          infoText: this.$t('dataGrid.pagerInfo')
        },
        paging: {
          enabled: true,
          pageSize: this.config.rowOnPage || 50
        },
        loadPanel: {
          enabled: true,
          height: 100,
          width: 100,
          showIndicator: true,
          showPane: true,
          indicatorSrc: '',
          shading: true,
          text: this.$t('dataGrid.loading')
        },
        filterRow: {
          visible: true,
          applyFilter: 'auto',
          applyFilterText: this.$t('dataGrid.filters.applyFilter'),
          betweenStartText: this.$t('dataGrid.filters.betweenStart'),
          betweenEndText: this.$t('dataGrid.filters.betweenEnd'),
          resetOperationText: this.$t('dataGrid.filters.reset'),
          showAllText: this.$t('dataGrid.filters.showAll'),
          showOperationChooser: true,
          operationDescriptions: {
            equal: this.$t('dataGrid.filters.operationDescriptions.equal'),
            notEqual: this.$t('dataGrid.filters.operationDescriptions.notEqual'),
            greaterThan: this.$t('dataGrid.filters.operationDescriptions.greaterThan'),
            greaterThanOrEqual: this.$t(
              'dataGrid.filters.operationDescriptions.greaterThanOrEqual'
            ),
            lessThan: this.$t('dataGrid.filters.operationDescriptions.lessThan'),
            lessThanOrEqual: this.$t('dataGrid.filters.operationDescriptions.lessThanOrEqual'),
            between: this.$t('dataGrid.filters.operationDescriptions.between'),
            contains: this.$t('dataGrid.filters.operationDescriptions.contains'),
            notContains: this.$t('dataGrid.filters.operationDescriptions.notContains'),
            startsWith: this.$t('dataGrid.filters.operationDescriptions.startsWith'),
            endsWith: this.$t('dataGrid.filters.operationDescriptions.endsWith'),
            empty: this.$t('dataGrid.filters.operationDescriptions.empty'),
            notEmpty: this.$t('dataGrid.filters.operationDescriptions.notEmpty')
          }
        },
        sorting: {
          mode: this.config.allowSort === false ? 'none' : 'multiple',
          showSortIndexes: true,
          ascendingText: this.$t('dataGrid.sorting.ascending'),
          descendingText: this.$t('dataGrid.sorting.descending'),
          clearText: this.$t('dataGrid.sorting.clear')
        },
        fixing: {
          enabled: false
        },
        scrolling: {
          mode: this.config.virtualScroll ? 'virtual' : 'standard',
          rowRenderingMode: this.config.virtualScroll ? 'virtual' : 'standard'
        }
      }
    },
    selectedRowKey: function () {
      if (this.selectedRowData) {
        return this.selectedRowData[this.config.key]
      } else {
        return null
      }
    },
    selectedRowData: function () {
      return this.$data.$selectedRow
    },
    customCells: function () {
      return Object.entries(CustomCells).map(([key, value]) => ({
        type: key,
        ...value
      }))
    }
  },
  methods: {
    isGroup: function (arr) {
      return arr.some(e => e === 'or' || e === 'and')
    },
    checkIfExists: function (array, searchItem) {
      for (const item of array) {
        if (Array.isArray(item)) {
          if (this.checkIfExists(item, searchItem)) {
            return true
          }
        }
        if (item === searchItem) {
          return true
        }
      }
    },
    getGroups (array, itemToAvoid, finalArray) {
      for (const item of array) {
        if (Array.isArray(item)) {
          if (this.isGroup(item) && !this.isGroup(item[0])) {
            if (item[0][0] !== itemToAvoid) {
              finalArray.push(item)
            }
          } else {
            this.getGroups(item, itemToAvoid, finalArray)
          }
        }
      }
    },
    newFitler (array, itemToAvoid) {
      const groupsArray = []
      this.getGroups(array, itemToAvoid, groupsArray)
      if (groupsArray.length > 0) {
        let arrayToReturn = groupsArray[0]
        for (let i = 1; i < groupsArray.length; i++) {
          arrayToReturn = [arrayToReturn, 'and', groupsArray[i]]
        }
        return arrayToReturn
      }
      return []
    },
    $optionChanged: function (event) {
      if (!event.fullName.includes('selectedFilterOperation')) return
      if (
        !(
          event.value === 'empty' ||
          event.value === 'notEmpty' ||
          event.previousValue === 'empty' ||
          event.previousValue === 'notEmpty'
        )
      ) { return }
      const columnId = event.fullName.substring(
        event.fullName.indexOf('[') + 1,
        event.fullName.indexOf('[') + 2
      )
      const columnName = this.$columns[columnId].name

      let currentFilter = this.$refs.grid.instance.filter()

      let filterArray = []
      if (currentFilter) {
        if (this.checkIfExists(currentFilter, columnName)) {
          currentFilter = this.newFitler(currentFilter, columnName)
        }
        if (currentFilter.length > 0) {
          filterArray = currentFilter
        }
      }

      if (event.value === 'empty' || event.value === 'notEmpty') {
        let filterExpression
        if (event.value === 'empty') {
          filterExpression = [[columnName, '=', ''], 'or', [columnName, '=', null]]
        } else if (event.value === 'notEmpty') {
          filterExpression = [[columnName, '<>', ''], 'and', [columnName, '<>', null]]
        }
        if (filterArray.length > 0) {
          filterArray = [filterArray, 'and', filterExpression]
        } else {
          filterArray = filterExpression
        }
      }

      if (filterArray.length === 0) {
        filterArray = null
      }

      this.$refs.grid.instance.filter(filterArray)
    },
    $onSelectionChanged: function (event) {
      const data = event.selectedRowsData[0]
      console.log(this.$data)
      this.$data.$selectedRow = data
      console.log(this.$data)
      this.$emit('click', {
        key: this.selectedRowKey,
        data: this.selectedRowData
      })
    },
    $onToolbarPreparing: function (event) {
      const searchPanel = event.toolbarOptions.items.find(x => x.name === 'searchPanel')
      if (searchPanel) {
        searchPanel.location = 'center'
        event.toolbarOptions.visible = true
      } else {
        event.toolbarOptions.visible = false
      }
    },
    $onCellClick: function (event) {
      Array.from(
        event.component.element().getElementsByClassName('rs-dx-datagrid-cell-selected')
      ).forEach(function (el) {
        el.classList.remove('rs-dx-datagrid-cell-selected')
      })

      if (event.rowType !== 'header' && event.rowType !== 'filter') {
        event.cellElement.classList.add('rs-dx-datagrid-cell-selected')
        if (this.config.selectionMode === 'singlerow') {
          event.cellElement.parentElement.children.forEach(e => {
            e.classList.add('rs-dx-datagrid-cell-selected')
          })
        }
      }
    },
    $onCellDoubleClick: function (event) {
      this.$emit('doubleClick', {
        key: this.selectedRowKey,
        data: this.selectedRowData,
        columnType: event.column.dataType
      })
    },
    $onCellPrepared: function (event) {
      if (event.rowType === 'filter') {
        if (
          event.column.selectedFilterOperation === 'empty' ||
          event.column.selectedFilterOperation === 'notEmpty'
        ) {
          event.cellElement.ariaDisabled = true
          event.cellElement.disabled = true
          this.$nextTick(() => {
            this.$optionChanged({
              fullName: `selectedFilterOperation[${event.columnIndex}]`,
              value: event.column.selectedFilterOperation
            })
          })
        }
      }
      if (this.$useCustomRendering) {
        if (event.rowType !== 'data') {
          return
        }
        const column = this.config.columns.find(e => e.name === event.column.name)
        if (!column) {
          return
        }

        if (column.textColor) {
          event.cellElement.style.color = column.textColor
        }
        if (column.textColorColumn) {
          event.cellElement.style.color = event.data[column.textColorColumn]
        }
        if (column.backgroundColor) {
          event.cellElement.style.backgroundColor = column.backgroundColor
        }
        if (column.backgroundColorColumn) {
          event.cellElement.style.backgroundColor = event.data[column.backgroundColorColumn]
        }
        if (column.multiline) {
          event.cellElement.style.whiteSpace = 'pre'
        }
      }
    },
    $onRowPrepared: function (event) {
      if (event.rowType !== 'data') {
        return
      }

      if (this.config.rowMinHeight) {
        event.rowElement.style.height = this.config.rowMinHeight + 'px'
      }
    },
    refresh: function () {
      return this.$refs.grid.instance.refresh().then(() => {
        const data = this.$refs.grid.instance.getSelectedRowsData()

        this.$onSelectionChanged({ selectedRowsData: data })
      })
    }
  }
}
</script>
<style scoped>
#gridContainer {
  height: auto;
  cursor: pointer;
  max-width: none !important;
}

#gridContainer .dx-datagrid-content tr.dx-data-row {
  cursor: pointer;
}

.options {
  padding: 20px;
  margin-top: 20px;
  background-color: rgba(191, 191, 191, 0.15);
}

.caption {
  font-size: 18px;
  font-weight: 500;
}

.option {
  margin-top: 10px;
}

.option > span {
  margin-right: 10px;
}

.option > .dx-selectbox {
  display: inline-block;
  vertical-align: middle;
}

.employee-info .employee-photo {
  height: 140px;
  float: left;
  padding: 20px 20px 20px 0;
}

.employee-info .employee-notes {
  padding-top: 20px;
  text-align: justify;
  white-space: normal;
}
</style>
