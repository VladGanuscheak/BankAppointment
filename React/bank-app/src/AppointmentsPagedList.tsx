import { useState } from "react";
import { CircularProgress, makeStyles, Paper } from "@material-ui/core";
import { DataGrid, GridColDef } from "@material-ui/data-grid";
import { useQuery } from "react-query";
import { useApi } from "./api";

const useStyles = makeStyles((theme) => ({
  paper: {
    marginTop: 30,
    padding: 15,
  },
  table: {
    minWidth: 650,
  },
}));

const PAGE_SIZE = 10;

const columns: GridColDef[] = [
  { field: "bankName", headerName: "Bank", width: 230 },
  { field: "branchAddress", headerName: "Branch", width: 300 },
  { field: "serviceName", headerName: "Service", width: 230 },
  { field: "status", headerName: "Status" },
  { field: "arrivalDate", headerName: "Arrival Date", width: 200 },
];
export default () => {
  const [page, setPage] = useState(0);
  const { api } = useApi();
  const query = useQuery(["appointments", page], () =>
    api.appointments.getPage({ page: page + 1, take: PAGE_SIZE })
  );
  const classes = useStyles();

  if (query.isLoading || query.isIdle) return <CircularProgress />;
  if (query.isError) return <>Oh no</>;

  return (
    <Paper className={classes.paper} style={{ height: 500, width: "100%" }}>
      <DataGrid
        pagination
        rows={query.data.appointments}
        columns={columns}
        pageSize={PAGE_SIZE}
        getRowId={({ branchId, serviceId, userId }) =>
          `${branchId}_${serviceId}_${userId}`
        }
        onPageChange={(params) => setPage(params.page)}
        page={page}
        rowCount={query.data.totalNumberOfElements}
        paginationMode="server"
      />
    </Paper>
  );
};
