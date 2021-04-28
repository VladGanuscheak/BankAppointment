export interface Bank {
  bankId: number;
  bankName: string;
  url: string;
  branches: Branch[];
}

export interface Branch {
  branchId: number;
  phone: string;
  address: string;
  services: Service[];
}

export interface Service {
  serviceId: string;
  serviceName: string;
}

export interface Appointment {
  userId: string;
  userFirstName: string;
  userLastName: string;
  userEmail: string;
  serviceName: string;
  branchPhone: string;
  branchAddress: string;
  bankName: string;
  bankUrl: string;
  branchId: number;
  serviceId: number;
  appointmentStatus: AppointmentStatus;
  arrivalDate: string;
  arriveTime?: string;
}

export interface GetAppointmentsRequest {
  page: number;
  take: number;
}

export interface GetAppointmentsPage {
  totalNumberOfElements: number;
  appointments: Appointment[];
}

enum AppointmentStatus {
  New = 0,
  Refused = 1,
  Finished = 2,
}

export interface ScheduleAppointmentRequest {
  userId: string;
  branchId: number;
  serviceId: number;
  appointmentStatus: AppointmentStatus;
  arrivalDate: string;
  arriveTime?: string;
}
