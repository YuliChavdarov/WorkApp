import * as React from 'react';
import Typography from '@mui/material/Typography';
import Grid from '@mui/material/Grid';
import TextField from '@mui/material/TextField';
import CreateProfileContext from '../../contexts/CreateProfileContext';

export default function AboutYou() {

    const { infoState, addToState } = React.useContext(CreateProfileContext);

    const handleInfoInput = (e) => {
        addToState(e.target.id, e.target.value);
    }

    return (
        <Grid container spacing={3}>
            <Grid item xs={12} >
                <Typography sx={{ mt: 2 }} fontWeight="bold">
                    Add a title to tell the world what you do
                </Typography>
                <Typography color="text.secondary">
                    It's the very first thing clients see, so make it count
                </Typography>
                <TextField
                    required
                    id="title"
                    label="Title"
                    defaultValue={infoState.title}
                    fullWidth
                    variant="standard"
                    onBlur={handleInfoInput}
                />
            </Grid>

            {/* <Grid item xs={12} >
                <Typography sx={{ mt: 2 }} fontWeight="bold">
                    Your skills
                </Typography>
                <Typography color="text.secondary">
                    Show your clients what you can offer
                </Typography>
                <TextField
                    required
                    id="skills"
                    label="Skills"
                    defaultValue={infoState.skills}
                    fullWidth
                    variant="standard"
                />
            </Grid> */}

            <Grid item xs={12} >
                <Typography sx={{ mt: 2 }} fontWeight="bold">
                    Write a description
                </Typography>
                <Typography color="text.secondary">
                    Tell the world about yourself. You can always edit it later
                </Typography>
                <TextField
                    multiline
                    required
                    minRows={3}
                    defaultValue={infoState.description}
                    placeholder="Describe your top skills, experiences and interests."
                    id="description"
                    label="Description"
                    fullWidth
                    variant="standard"
                    onBlur={handleInfoInput}
                />
            </Grid>
        </Grid>
    );
}