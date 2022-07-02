import { createRouter, createWebHistory } from 'vue-router'
import Administration from '../views/Administration.vue'
import cookies from 'vue-cookies'
import store from '../store'

const routes = [
  {
    path: '/administration',
    name: 'administration',
    component: Administration
  },
  {
    path: '/login',
    name: 'login',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/Login.vue')
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

router.beforeEach(async (to, from, next) => {
  if (cookies.get('Authorization')) {
    store.dispatch('application/setUserInfo')
    if (to.path === '/login') {
      next('/administration')
    }
    next()
  } else {
    if (to.path === '/login') {
      next()
    } else {
      next('/login')
    }
  }
})

export default router
