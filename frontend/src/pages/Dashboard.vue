<template>
  <section class="text-center space-y-4">
    <h1 class="text-3xl font-bold text-primary">Welcome to SupportPlatform</h1>
    <p class="text-gray-600">Manage your tickets and track their progress easily.</p>

    <div class="mt-10 pt-10 grid gap-6 sm:grid-cols-2 max-w-2xl mx-auto">
      <router-link
        to="/tickets"
        class="bg-white shadow rounded-lg p-6 hover:shadow-md border border-gray-200 transition text-left"
      >
        <h2 class="text-xl font-semibold text-primary mb-2">View Tickets</h2>
        <p class="text-gray-600">See all existing support tickets and track their status.</p>
      </router-link>

      <router-link
        to="/tickets/create"
        class="bg-white shadow rounded-lg p-6 hover:shadow-md border border-gray-200 transition text-left"
      >
        <h2 class="text-xl font-semibold text-primary mb-2">Create New Ticket</h2>
        <p class="text-gray-600">Need help? Submit a new support request here.</p>
      </router-link>
    </div>
  </section>
</template>

<script>
import DefaultLayout from '@/layouts/DefaultLayout.vue'

export default {
  layout: DefaultLayout
}
</script>
