import Typography from "@mui/material/Typography";

export default function Copyright(sx) {
    return (
        <Typography variant="body2" color="text.secondary" align="center" {...sx}>
            Copyright © WorkApp {new Date().getFullYear()}
        </Typography>
    );
}