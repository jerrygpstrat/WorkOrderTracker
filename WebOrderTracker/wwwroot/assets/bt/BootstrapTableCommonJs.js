// This is the currency formatter
function currencyFormatter(value, row, index) {
    if (value === undefined || value === null) {
        return '$0.00';
    }

    // Formats numbers gracefully into US Dollars
    return new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD'
    }).format(value);
}