import type { Component } from 'vue'

declare module 'vue' {
  export interface ComponentCustomOptions {
    layout?: Component
  }
}
