import type { Pinia } from 'pinia'
import type { App } from 'vue'

declare module 'pinia' {
  interface Pinia {
    install: (app: App) => void
  }
}
