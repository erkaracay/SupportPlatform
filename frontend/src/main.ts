import { createApp } from 'vue'
import App from './App.vue'
import './style.css'

import { createPinia } from 'pinia'
import { router } from './router'

const app = createApp(App)

app.use(createPinia() as any)
app.use(router)

app.mount('#app')
