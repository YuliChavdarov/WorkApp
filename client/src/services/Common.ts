const headers = {
	'Content-Type' : 'application/json',
	"Accept" : 'application/json'
};

export const getHeaders = (token?: string) => {
	return token
		? {
				...headers,
				"Authorization": `Bearer ${token}`
			}
		: headers;
};