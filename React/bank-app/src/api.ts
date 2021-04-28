import { createContext, useContext } from "react";
import {
  Bank,
  GetAppointmentsPage,
  GetAppointmentsRequest,
  ScheduleAppointmentRequest,
} from "./models";

export interface ApiConfig {
  base: string;
}

export const defaultConfig: ApiConfig = {
  base: "https://localhost:5001/api",
};

export const createApi = ({ base }: ApiConfig) => ({
  banks: {
    getAll: (): Promise<Bank[]> =>
      fetch(`${base}/Banks`)
        .then((res) => res.json())
        .then((r) => r.banks),
  },
  appointments: {
    getPage: ({
      page,
      take,
    }: GetAppointmentsRequest): Promise<GetAppointmentsPage> =>
      fetch(
        `${base}/appointments/getPaginatedAppointments?page=${page}&take=${take}`
      ).then((res) => res.json()),
    schedule: (request: ScheduleAppointmentRequest) =>
      fetch(`${base}/appointments/ScheduleAppointment`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(request),
      }),
  },
  // services: ()
});
export const ApiContext = createContext({ api: createApi(defaultConfig) });

export const useApi = () => useContext(ApiContext);
