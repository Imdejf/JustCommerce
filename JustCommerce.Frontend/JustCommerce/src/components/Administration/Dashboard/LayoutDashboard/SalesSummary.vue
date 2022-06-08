<template>
  <DoughnutChart :chartData="testData" :showLine="false" />
</template>

<script>
import { DoughnutChart } from 'vue-chart-3'
import { Chart, registerables } from 'chart.js'

Chart.register(...registerables)
export default ({
  name: 'Home',
  components: { DoughnutChart },
  setup () {
    const testData = {
      labels: ['Styczeń', 'Luty', 'Marzec'],
      datasets: [
        {
          data: [70, 20, 10],
          backgroundColor: ['#fad12c', '#3453b7', '#fa812d']
        }
      ]
    }

    return { testData }
  }
})
</script>
