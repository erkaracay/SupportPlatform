import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'

import Dashboard from '@/pages/Dashboard.vue'
import TicketList from '@/pages/TicketList.vue'
import CreateTicket from '@/pages/CreateTicket.vue'
import Login from '@/pages/Login.vue'
import SingleTicket from '@/pages/SingleTicket.vue'

const routes: RouteRecordRaw[] = [
  { path: '/', redirect: '/dashboard' },
  { path: '/dashboard', component: Dashboard },
  { path: '/tickets', component: TicketList },
  { path: '/tickets/create', component: CreateTicket },
  { path: '/login', component: Login },
  { path: '/tickets/:id', component: SingleTicket }
]

export const router = createRouter({
  history: createWebHistory(),
  routes
})
