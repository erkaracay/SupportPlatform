import axios from 'axios'
import { TicketDto } from '@/types/TicketDto'

const api = axios.create({
  baseURL: 'http://localhost:5297/api',
})

export const getTickets = () => api.get<TicketDto[]>('/ticket')
export const getTicket = (id: string) => api.get<TicketDto>(`/ticket/${id}`)
export const createTicket = (ticket: Partial<TicketDto>) => api.post('/ticket', ticket)
export const updateTicket = (id: string, ticket: Partial<TicketDto>) => api.put(`/ticket/${id}`, ticket)
export const deleteTicket = (id: string) => api.delete(`/ticket/${id}`)
