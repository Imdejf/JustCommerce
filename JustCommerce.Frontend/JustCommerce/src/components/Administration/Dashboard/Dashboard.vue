<template>
    <b-row>
      <button @click="itemTitle()">test</button>
      <b-col class="b-column" cols="10" md="6" lg="3">
        <b-card class="b-card mb-4">
          <h4 class="card-title mb-1">+70%</h4>
          <b-card-text class="mb-2">{{ $t("dashboard.dailySales") }}</b-card-text>
          <b-progress value="70" max="100"></b-progress>
        </b-card>
      </b-col>
      <b-col class="b-column" cols="12" md="6" lg="3">
        <b-card class="b-card mb-4">
          <h4 class="card-title mb-1">10%</h4>
          <b-card-text class="mb-2">{{ $t("dashboard.monthlySales") }}</b-card-text>
          <b-progress variant="danger" value="10" max="100"></b-progress>
        </b-card>
      </b-col>
      <b-col class="b-column" cols="12" md="6" lg="3">
        <b-card class="b-card mb-4">
          <h4 class="card-title mb-1">50</h4>
          <b-card-text class="mb-2">{{ $t("dashboard.numberOrder") }}</b-card-text>
          <b-progress variant="success" value="50" max="100"></b-progress>
        </b-card>
      </b-col>
      <b-col class="b-column" cols="12" md="6" lg="3">
        <b-card class="b-card mb-4">
          <h4 class="card-title mb-1">30%</h4>
          <b-card-text class="mb-2">{{ $t("dashboard.turnOver" )}}</b-card-text>
          <b-progress variant="warning" value="30" max="100"></b-progress>
        </b-card>
      </b-col>
    </b-row>
    <grid-layout v-model:layout="layout"
                 :col-num="12"
                 :row-height="30"
                 :is-draggable="draggable"
                 :is-resizable="resizable"
                 :vertical-compact="true"
                 :use-css-transforms="true"
    >
        <grid-item v-for="item in layout" :key="item"
                   :static="item.static"
                   :x="item.x"
                   :y="item.y"
                   :w="item.w"
                   :h="item.h"
                   :i="item.i"
        >
            <component :is="item.c"></component>
        </grid-item>
    </grid-layout>
</template>

<script>
import { GridLayout, GridItem } from 'vue3-grid-layout'
import SalesSummary from '@/components/Administration/Dashboard/LayoutDashboard/SalesSummary'
import SalesIncome from '@/components/Administration/Dashboard/LayoutDashboard/SalesIncome'
import LineChart from '@/components/Administration/Dashboard/LayoutDashboard/LineChart'
import NewProduct from '@/components/Administration/Dashboard/LayoutDashboard/NewProduct'

export default {
  components: {
    GridLayout,
    GridItem,
    SalesSummary,
    SalesIncome,
    LineChart,
    NewProduct
  },
  data () {
    return {
      layout: [
        { x: 0, y: 0, w: 6, h: 6, i: '0', c: 'SalesSummary', static: false },
        { x: 6, y: 0, w: 6, h: 6, i: '1', c: 'SalesIncome', static: false },
        { x: 0, y: 2, w: 20, h: 6, i: '2', c: 'LineChart', static: false },
        { x: 0, y: 4, w: 20, h: 6, i: '2', c: 'NewProduct', static: false }
      ],
      draggable: true,
      resizable: true,
      index: 0
    }
  },
  methods: {
    itemTitle () {
      this.$toast('Im a toast!', {
        // toast opitons here
      })
    }
  }
}
</script>

<style scoped>
.vue-grid-layout {
}
.vue-grid-item:not(.vue-grid-placeholder) {
    background: white;
    box-shadow: 1px solid black;
}
.vue-grid-item div{
  height: 100%;
}

.vue-grid-item .resizing {
    opacity: 0.9;
}
.vue-grid-item .static {
    background: #cce;
}
.vue-grid-item .text {
    font-size: 24px;
    text-align: center;
    position: absolute;
    top: 0;
    bottom: 0;
    left: 0;
    right: 0;
    margin: auto;
    height: 100%;
    width: 100%;
}
.vue-grid-item .no-drag {
    height: 100%;
    width: 100%;
}
.vue-grid-item .minMax {
    font-size: 12px;
}
.vue-grid-item .add {
    cursor: pointer;
}
.vue-draggable-handle {
    position: absolute;
    width: 20px;
    height: 20px;
    top: 0;
    left: 0;
    background: url("data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='10' height='10'><circle cx='5' cy='5' r='5' fill='#999999'/></svg>") no-repeat;
    background-position: bottom right;
    padding: 0 8px 8px 0;
    background-repeat: no-repeat;
    background-origin: content-box;
    box-sizing: border-box;
    cursor: pointer;
}
</style>
© 2022 GitHub, Inc.
Terms
Privacy
Security
Status
Docs
Contact GitHub
Pricing
API
Training
Blog
About
