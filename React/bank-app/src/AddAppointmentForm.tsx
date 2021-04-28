import React, { useEffect, useMemo, useState } from "react";

import {
  Paper,
  FormControl,
  InputLabel,
  Select,
  MenuItem,
  makeStyles,
  Button,
  CircularProgress,
  Typography,
} from "@material-ui/core";
import { Bank, ScheduleAppointmentRequest } from "./models";
import { DateTimePicker } from "@material-ui/pickers";
import { useSettings } from "./settings-store";
import { useApi } from "./api";
import { useMutation, useQueryClient } from "react-query";

export interface AddAppointmentsProps {
  banks: Bank[];
}

const useStyles = makeStyles((theme) => ({
  formControl: {
    margin: theme.spacing(1),
    minWidth: 120,
  },
  selectEmpty: {
    marginTop: theme.spacing(2),
  },
  paper: {
    padding: 15,
  },
}));

const initialForm = {
  arrivalDate: new Date().toISOString(),
};

export default ({ banks }: AddAppointmentsProps) => {
  const { api } = useApi();
  const queryClient = useQueryClient();

  const classes = useStyles();
  const [form, setForm] = useState<Partial<ScheduleAppointmentRequest>>(
    initialForm
  );

  const aMutation = useMutation(api.appointments.schedule, {
    onSuccess: (data) => {
      setForm(initialForm);
      queryClient.invalidateQueries("appointments");
    },
  });
  const [bankId, setBankId] = useState<number | undefined>(undefined);
  const branches = useMemo(
    () => banks.find((b) => b.bankId === bankId)?.branches,
    [bankId]
  );
  const services = useMemo(
    () => branches?.find((b) => b.branchId === form.branchId)?.services,
    [form.branchId]
  );
  const { settings } = useSettings();

  useEffect(() => setForm({ ...form, branchId: undefined }), [bankId]);
  useEffect(() => setForm({ ...form, serviceId: undefined }), [services]);

  const validSubmit = useMemo(
    () => form.branchId && form.arrivalDate && form.serviceId,
    [form]
  );

  const submit = () => {
    const {
      branchId,
      arrivalDate,
      serviceId,
    } = form as ScheduleAppointmentRequest;
    const { userId } = settings;
    aMutation.mutate({
      branchId,
      serviceId,
      arrivalDate,
      userId,
      appointmentStatus: 0,
    });
  };

  return (
    <Paper className={classes.paper}>
      <div>
        <FormControl className={classes.formControl}>
          <InputLabel>Bank</InputLabel>
          <Select
            onChange={(e) => setBankId(e.target.value as number)}
            value={bankId ?? ""}
          >
            {banks.map((b) => (
              <MenuItem key={b.bankId} value={b.bankId}>
                {b.bankName}
              </MenuItem>
            ))}
          </Select>
        </FormControl>
        {branches && (
          <FormControl className={classes.formControl}>
            <InputLabel>Branch</InputLabel>
            <Select
              value={form.branchId ?? ""}
              onChange={(e) =>
                setForm({ ...form, branchId: e.target.value as number })
              }
            >
              {branches.map((b) => (
                <MenuItem key={b.branchId} value={b.branchId}>
                  {b.address}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
        )}
        {services && (
          <FormControl className={classes.formControl}>
            <InputLabel>Service</InputLabel>
            <Select
              value={form.serviceId ?? ""}
              onChange={(e) =>
                setForm({ ...form, serviceId: e.target.value as number })
              }
            >
              {services.map(({ serviceId, serviceName }) => (
                <MenuItem key={serviceId} value={serviceId}>
                  {serviceName}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
        )}
      </div>
      <div>
        <FormControl className={classes.formControl}>
          <DateTimePicker
            label="Arrival Date"
            value={form.arrivalDate}
            onChange={(e) =>
              setForm({ ...form, arrivalDate: e?.toISOString() })
            }
          />
        </FormControl>
      </div>
      <div>
        <FormControl className={classes.formControl}>
          <Button
            variant="contained"
            color="primary"
            disabled={!validSubmit || aMutation.isLoading}
            onClick={submit}
          >
            Create
          </Button>
        </FormControl>
        <FormControl>{aMutation.isLoading && <CircularProgress />}</FormControl>
      </div>
      <div>
        <FormControl>
          {aMutation.isError && (
            <Typography color="error">Something went wrong</Typography>
          )}
        </FormControl>
      </div>
    </Paper>
  );
};
