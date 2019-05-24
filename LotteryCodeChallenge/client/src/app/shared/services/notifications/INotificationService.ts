export interface INotificationService {
  // Displays a standard informational notification
  notify(text: string);
  // Displays a error notification
  notifyError(text: string, errorInfo: Error);
  // Displays a 'operation successful' notification
  notifySuccess(text: string);
}
