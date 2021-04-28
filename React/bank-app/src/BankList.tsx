import {
  Accordion,
  AccordionDetails,
  AccordionSummary,
  Box,
  Chip,
  CircularProgress,
  Link,
  List,
  ListItem,
  ListItemSecondaryAction,
  ListItemText,
  Paper,
  Typography,
} from "@material-ui/core";
import {
  ExpandMore as ExpandMoreIcon,
  Link as LinkIcon,
} from "@material-ui/icons";
import React from "react";
import { useQuery } from "react-query";
import { useApi } from "./api";


export default () => {
  const { api } = useApi();
  const q = useQuery("banks", api.banks.getAll);

  if (q.status === "loading" || q.status === "idle")
    return <CircularProgress />;

  if (q.status === "error") return <>Oh no ...</>;

  const banks = q.data;

  return (
    <Paper>
      {banks.map(({ bankId, bankName, branches, url }) => (
        <Accordion key={bankId}>
          <AccordionSummary expandIcon={<ExpandMoreIcon />}>
            <Box display="flex">
              <Box p={1}>
                <Link href={`https://${url}`}>
                  <LinkIcon />
                </Link>
              </Box>
              <Box p={1}>
                <Typography>{bankName}</Typography>
              </Box>
            </Box>
          </AccordionSummary>
          <AccordionDetails>
            <List style={{ width: "100%" }}>
              {branches.map((b) => (
                <ListItem key={b.branchId}>
                  <ListItemText>{b.address}</ListItemText>
                  <ListItemSecondaryAction>
                    {b.services.map((s) => (
                      <Chip key={s.serviceId} label={s.serviceName} />
                    ))}
                  </ListItemSecondaryAction>
                </ListItem>
              ))}
            </List>
            <Typography></Typography>
          </AccordionDetails>
        </Accordion>
      ))}
    </Paper>
  );
};
