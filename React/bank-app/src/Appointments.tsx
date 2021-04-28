import { CircularProgress } from "@material-ui/core";
import { useQuery } from "react-query";
import { useApi } from "./api";
import AddAppointmentForm from "./AddAppointmentForm";
import AppointmentsPagedList from "./AppointmentsPagedList";

export default () => {
  const { api } = useApi();
  const banksQuery = useQuery("banks", api.banks.getAll);


  if (banksQuery.isError) return <>Oh no...</>
  if (banksQuery.isLoading || banksQuery.isIdle) return <CircularProgress />

  return (
    <div>
      <AddAppointmentForm banks={banksQuery.data} />
      <AppointmentsPagedList />
    </div>
  );
};
