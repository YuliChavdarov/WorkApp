import * as React from 'react';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import TextField from '@mui/material/TextField';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import Link from '@mui/material/Link';

import { Link as RouterLink, useNavigate } from 'react-router-dom';

import registerImage from '../images/register-image.jpg';
import { register } from '../services/UsersService';

import '../styles/Register.css';

import AuthContext from '../contexts/AuthContext';
import Copyright from './Copyright';

export default function Register() {

    const [isClient, setIsClient] = React.useState(false);
    const authContext = React.useContext(AuthContext);
    const navigate = useNavigate();

    const handleUserTypeChange = (e) => {
        setIsClient(!isClient);
    }

    const handleSubmit = async (event) => {
        event.preventDefault();
        const data = new FormData(event.currentTarget);

        const firstName = data.get('firstName');
        const lastName = data.get('lastName');
        const email = data.get('email');
        const password = data.get('password');

        const userType = isClient ? "client" : "worker";

        const result = await register(userType, firstName, lastName, email, password);

        if (result.token) {
            authContext.login(result.token);
            navigate("/create-profile");
        }
        else {
            console.log(result);
        }
    };

    return (
        <Container component="main"
            sx={{
                backgroundColor: "#fff",
                borderRadius: "10px",
                mt: 8
            }}
        >
            <CssBaseline />

            <Grid container>

                <Grid item md={5} display={{ xs: "none", md: 'block' }} sx={{ alignSelf: "center" }}>
                    <img
                        src={registerImage}
                        style={{ display: 'block', marginLeft: "auto", marginRight: "auto" }}
                        alt="register-img"
                    />
                </Grid>

                <Grid item md={7}>
                    <Box
                        sx={{
                            mt: 8,
                            mx: 4,
                            display: 'flex',
                            flexDirection: 'column',
                            alignItems: 'center',
                        }}
                    >
                        <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
                            <LockOutlinedIcon />
                        </Avatar>
                        <Typography component="h1" variant="h5">
                            Register to WorkApp
                        </Typography>

                        <Box className="switch-button">
                            <input className="switch-button-checkbox" type="checkbox" id="userType" checked={isClient} onChange={handleUserTypeChange} />
                            <label className="switch-button-label"><span className="switch-button-label-span">Worker</span></label>
                        </Box>

                        <Box component="form" onSubmit={handleSubmit} width={{ xs: "100%", md: "80%" }} noValidate sx={{ mt: 1 }}>

                            <Grid container spacing={2}>
                                <Grid item xs={12} md={6}>
                                    <TextField
                                        margin="normal"
                                        required
                                        fullWidth
                                        id="firstName"
                                        label="First Name"
                                        name="firstName"
                                        autoComplete="firstName"
                                        autoFocus
                                    />
                                </Grid>
                                <Grid item xs={12} md={6}>
                                    <TextField
                                        margin="normal"
                                        required
                                        fullWidth
                                        id="lastName"
                                        label="Last Name"
                                        name="lastName"
                                        autoComplete="lastName"
                                    />
                                </Grid>
                            </Grid>

                            <TextField
                                margin="normal"
                                required
                                fullWidth
                                id="email"
                                label="Email Address"
                                name="email"
                                autoComplete="email"
                            />
                            <TextField
                                margin="normal"
                                required
                                fullWidth
                                name="password"
                                label="Password"
                                type="password"
                                id="password"
                                autoComplete="current-password"
                            />
                            <Button
                                type="submit"
                                fullWidth
                                variant="contained"
                                sx={{ mt: 3, mb: 2 }}
                            >
                                Register
                            </Button>
                        </Box>
                    </Box>

                    <Box sx={{ textAlign: "center", mt: 1 }}>
                        <Link component={RouterLink} to="/login" variant="body2">
                            Already have an account? Log in
                        </Link>
                    </Box>
                    <Copyright sx={{ mt: 4, mb: 4 }} />
                </Grid>
            </Grid>
        </Container>
    );
}