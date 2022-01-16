const headers = {
	'Content-Type' : 'application/json',
	"Accept" : 'application/json'
};

export const getHeaders = (token = null) => {
	return token
		? {
				...headers,
				"Authorization": `Bearer ${token}`
			}
		: headers;
};