export interface TicketDto {
  id: string
  title: string
  description: string
  createdAt: string
  status: 'Open' | 'InProgress' | 'Closed'
  priority: 'Low' | 'Medium' | 'High'
  companyId: string
  createdByUserId: string
}
