import Typography from "@mui/material/Typography";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import Grid from "@mui/material/Grid";

import { Link as RouterLink } from 'react-router-dom';

import notFoundImage from '../images/404-not-found.jpg';

export default function PageNotFound() {
    return (
        <Box component="main" sx={{ height: "100vh", backgroundColor: "#FFF", textAlign: "center" }}>
            <Grid container>
                <Grid item md={2} lg={3}/>
                <Grid item md={8} lg={6}>
                    <img
                        src={notFoundImage}
                        style={{ display: 'block', marginLeft: "auto", marginRight: "auto" }}
                        alt="login-img"
                        width="100%"
                    />
                </Grid>
            </Grid>

            <Box>
                <Typography variant="h4" sx={{ pt: 2 }}>
                    Looking for something?
                </Typography>

                <Typography paragraph sx={{ pt: 2, px: 2 }}>
                    We can't find this page, but we can help you find new opportunities.
                </Typography>

                <Button component={RouterLink} to="/" variant="contained">
                    Go to homepage
                </Button>

                <Typography variant="body2" color="text.secondary" align="center" sx={{ mt: 6 }}>
                    Copyright © WorkApp {new Date().getFullYear()}
                </Typography>
            </Box>
        </Box>
    );
}